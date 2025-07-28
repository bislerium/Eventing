using Eventing.ApiService.Controllers.Account.Dto;
using Eventing.ApiService.Data;
using Eventing.ApiService.Data.Entities;
using Eventing.ApiService.Services.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Eventing.ApiService.Controllers.Account;

public class AccountController(
    UserManager<IdentityUser<Guid>> userManager,
    EventingDbContext dbContext,
    SignInManager<IdentityUser<Guid>> signInManager,
    JwtTokenService jwtTokenService) : ApiBaseController
{
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType<LoginResponseDto>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto dto)
    {
        var user = await userManager.FindByEmailAsync(dto.Email);
        if (user == null) return Problem(title: SignInResult.Failed.ToString(), statusCode: StatusCodes.Status401Unauthorized);

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
    public async Task<IActionResult> Register([FromBody] RegisterUserRequestDto dto)
    {
        IdentityUser<Guid> user = dto;

        var result = await userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded) return ValidationProblem(CreateValidationProblemDetails(result.Errors));
        
        await userManager.AddToRoleAsync(user, "General");

        dbContext.Set<Profile>().Add(dto);
        await dbContext.SaveChangesAsync();

        return Ok();
    }

    private ValidationProblemDetails CreateValidationProblemDetails(IEnumerable<IdentityError> errors)
    {
        var modelState = new ModelStateDictionary();

        foreach (var error in errors)
        {
            modelState.AddModelError(error.Code, error.Description);
        }

        return ProblemDetailsFactory.CreateValidationProblemDetails(HttpContext, modelState);
    }
}