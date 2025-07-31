using System.Text;
using System.Text.Encodings.Web;
using Eventing.ApiService.Controllers.Account.Dto;
using Eventing.ApiService.Data;
using Eventing.ApiService.Data.Entities;
using Eventing.ApiService.Services.Jwt;
using FluentEmail.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.WebUtilities;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Eventing.ApiService.Controllers.Account;

public class AccountController(
    UserManager<IdentityUser<Guid>> userManager,
    EventingDbContext dbContext,
    SignInManager<IdentityUser<Guid>> signInManager,
    JwtTokenService jwtTokenService,
    IFluentEmail fluentEmail) : ApiBaseController
{
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType<LoginResponseDto>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<LoginResponseDto>> LoginAsync([FromBody] LoginRequestDto dto)
    {
        var user = await userManager.FindByEmailAsync(dto.Email);
        if (user == null)
            return Problem(title: SignInResult.Failed.ToString(), statusCode: StatusCodes.Status401Unauthorized);

        var result = await signInManager.CheckPasswordSignInAsync(user, dto.Password, true);
        if (!result.Succeeded) return Problem(title: result.ToString(), statusCode: StatusCodes.Status401Unauthorized);

        var claimPrincipal = await signInManager.CreateUserPrincipalAsync(user);
        var (accessToken, expiresIn) = jwtTokenService.CreateToken(claimPrincipal.Claims);
        return Ok(new LoginResponseDto(accessToken, expiresIn));
    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterUserRequestDto dto)
    {
        IdentityUser<Guid> user = dto;

        var result = await userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded) return ValidationProblem(CreateValidationProblemDetails(result.Errors));

        await userManager.AddToRoleAsync(user, "General");

        dbContext.Set<Profile>().Add(dto);
        await dbContext.SaveChangesAsync();

        await SendConfirmationEmailAsync(user);

        return Ok();
    }

    [HttpGet("confirm-email", Name = "ConfirmEmail")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> ConfirmEmailAsync(
        [FromQuery] string userId,
        [FromQuery] string code)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user == null) return NotFound();

        try
        {
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
        }
        catch (FormatException)
        {
            return BadRequest();
        }

        var result = await userManager.ConfirmEmailAsync(user, code);

        if (!result.Succeeded) return Unauthorized();

        return Ok();
    }

    [HttpPost("resend-confirmation-email")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> ResendConfirmationEmailAsync([FromBody] ResendConfirmationEmailRequestDto dto)
    {
        var user = await userManager.FindByEmailAsync(dto.Email);
        if (user == null || user.EmailConfirmed) return Ok();

        await SendConfirmationEmailAsync(user);
        return Ok();
    }

    [HttpGet("confirm-change-email", Name = "ConfirmChangeEmail")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> ConfirmChangeEmailAsync(
        [FromQuery] string userId,
        [FromQuery] string code,
        [FromQuery] string newEmail)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user == null) return NotFound();

        try
        {
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
        }
        catch (FormatException)
        {
            return BadRequest();
        }

        var result = await userManager.ChangeEmailAsync(user, newEmail, code);

        if (!result.Succeeded) return Unauthorized();

        return Ok();
    }

    [HttpPost("forgot-password")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> ForgotPasswordAsync([FromBody] ForgotPasswordRequestDto dto)
    {
        var user = await userManager.FindByEmailAsync(dto.Email);

        // Don't reveal that the user does not exist or is not confirmed, so don't return a 200 if we had returned a 400 for an invalid code given a valid user email.
        if (user == null || !await userManager.IsEmailConfirmedAsync(user)) return Ok();
        var code = await userManager.GeneratePasswordResetTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        code = HtmlEncoder.Default.Encode(code);

        var email = await userManager.GetEmailAsync(user);
        await fluentEmail.To(email)
            .Subject("Reset your password")
            .Body($"Please reset your password using the following code: {code}", true)
            .HighPriority()
            .SendAsync();

        return Ok();
    }

    [HttpPost("reset-password")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPasswordRequestDto dto)
    {
        var user = await userManager.FindByEmailAsync(dto.Email);

        if (user is null || !await userManager.IsEmailConfirmedAsync(user))
        {
            // Don't reveal that the user does not exist or is not confirmed, so don't return a 200 if we had returned a 400 for an invalid code given a valid user email.
            return ValidationProblem(CreateValidationProblemDetails(userManager.ErrorDescriber.InvalidToken()));
        }

        IdentityResult result;
        try
        {
            var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(dto.ResetCode));
            result = await userManager.ResetPasswordAsync(user, code, dto.NewPassword);
        }
        catch (FormatException)
        {
            result = IdentityResult.Failed(userManager.ErrorDescriber.InvalidToken());
        }

        return result.Succeeded
            ? Ok()
            : ValidationProblem(CreateValidationProblemDetails(result.Errors));
    }


    private ValidationProblemDetails CreateValidationProblemDetails(params IEnumerable<IdentityError> errors)
    {
        var modelState = new ModelStateDictionary();

        foreach (var error in errors)
        {
            modelState.AddModelError(error.Code, error.Description);
        }

        return ProblemDetailsFactory.CreateValidationProblemDetails(HttpContext, modelState);
    }

    private async Task SendConfirmationEmailAsync(IdentityUser<Guid> user)
    {
        var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        var userId = await userManager.GetUserIdAsync(user);
        var confirmationLink = Url.Link(
            routeName: "ConfirmEmail",
            values: new { userId, code }
        );
        ArgumentNullException.ThrowIfNull(confirmationLink);

        confirmationLink = HtmlEncoder.Default.Encode(confirmationLink);
        var email = await userManager.GetEmailAsync(user);
        await fluentEmail.To(email)
            .Subject("Confirm Your Email Address")
            .Body($"Please confirm your email address by <a href='{confirmationLink}'>clicking here</a>.", true)
            .HighPriority()
            .SendAsync();
    }

    async Task SendChangeEmailAsync(IdentityUser<Guid> user, string newEmail)
    {
        var code = await userManager.GenerateChangeEmailTokenAsync(user, newEmail);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        var userId = await userManager.GetUserIdAsync(user);
        var confirmationLink = Url.Link(
            routeName: "ConfirmChangeEmail",
            values: new { userId, code, newEmail }
        );
        ArgumentNullException.ThrowIfNull(confirmationLink);

        confirmationLink = HtmlEncoder.Default.Encode(confirmationLink);
        await fluentEmail.To(newEmail)
            .Subject("Confirm Your New Email Address")
            .Body($"Please confirm your new email address by <a href='{confirmationLink}'>clicking here</a>.", true)
            .HighPriority()
            .SendAsync();
    }
}