using System.ComponentModel.DataAnnotations;

namespace Eventing.Web.Ui.Features.Event.Toolbar.ProfileMenu.Items.ChangePassword.Dialog.Dtos;

public sealed record ChangePasswordRequestDto(
    [Required] string OldPassword,
    [Required] string NewPassword);