using System.ComponentModel.DataAnnotations;

namespace Eventing.ApiService.Controllers.Account.Dto;

public sealed record ResendConfirmationEmailRequestDto(
    [Required] [EmailAddress] string Email);