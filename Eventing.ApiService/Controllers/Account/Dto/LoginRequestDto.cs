using System.ComponentModel.DataAnnotations;

namespace Eventing.ApiService.Controllers.Account.Dto;

public sealed record LoginRequestDto(
    [Required] [EmailAddress] string Email,
    string Password);