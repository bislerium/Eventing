using System.ComponentModel.DataAnnotations;

namespace Eventing.ApiService.Controllers.Account.Dto;

public sealed record ForgotPasswordRequestDto(
    [Required] [EmailAddress] string Email);