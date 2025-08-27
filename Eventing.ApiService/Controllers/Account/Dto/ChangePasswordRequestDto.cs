using System.ComponentModel.DataAnnotations;

namespace Eventing.ApiService.Controllers.Account.Dto;

public sealed record ChangePasswordRequestDto(
    [Required] string OldPassword,
    [Required] string NewPassword);