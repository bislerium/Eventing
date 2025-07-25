using Eventing.ApiService.Controllers.Account.Dto;
using Eventing.ApiService.Data;
using Eventing.ApiService.Data.Entities;
using Eventing.ApiService.Services.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto dto)
    {
        var user = await userManager.FindByEmailAsync(dto.Email);
        if (user == null) return Unauthorized();

        var result = await signInManager.CheckPasswordSignInAsync(user, dto.Password, true);
        if (!result.Succeeded) return Problem(result.ToString(), statusCode: StatusCodes.Status401Unauthorized);

        var claimPrincipal = await signInManager.CreateUserPrincipalAsync(user);
        var (accessToken, expiresIn) = jwtTokenService.CreateToken(claimPrincipal.Claims);
        return Ok(new LoginResponseDto(accessToken, expiresIn));
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequestDto dto)
    {
        IdentityUser<Guid> user = dto;
        
        var result = await userManager.CreateAsync(user, dto.Password);
        await userManager.AddToRoleAsync(user,"General");
        if (!result.Succeeded) return BadRequest(result.Errors);
        
        dbContext.Set<Profile>().Add(dto);
        await dbContext.SaveChangesAsync();
        return Ok();
    }
}