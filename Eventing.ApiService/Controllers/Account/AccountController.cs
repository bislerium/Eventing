using Eventing.ApiService.Controllers.Account.Dto;
using Eventing.ApiService.Data;
using Eventing.ApiService.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Eventing.ApiService.Controllers.Account;

public class AccountController(UserManager<IdentityUser<Guid>> userManager, EventingDbContext dbContext, SignInManager<IdentityUser<Guid>> signInManager) : ApiBaseController
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
    {
        var user = await userManager.FindByEmailAsync(dto.Email);
        await signInManager.SignInAsync(user, true);
        //var result = await signInManager.CheckPasswordSignInAsync(user, dto.Password, true);
        return Ok(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequestDto dto)
    {
        var result = await userManager.CreateAsync(dto, dto.Password);
        if (result.Succeeded)
        {
            dbContext.Set<Profile>().Add(dto);
            await dbContext.SaveChangesAsync();
        }

        return Ok(result);
    }
}