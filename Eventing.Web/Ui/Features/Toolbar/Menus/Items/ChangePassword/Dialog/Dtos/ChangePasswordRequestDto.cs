using System.ComponentModel.DataAnnotations;

namespace Eventing.Web.Ui.Features.Toolbar.Menus.Items.ChangePassword.Dialog.Dtos;

public sealed record ChangePasswordRequestDto(
    [Required] string OldPassword,
    [Required] string NewPassword);