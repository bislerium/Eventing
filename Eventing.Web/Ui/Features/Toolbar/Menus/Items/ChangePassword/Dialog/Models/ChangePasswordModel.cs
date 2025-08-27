using System.ComponentModel.DataAnnotations;

namespace Eventing.Web.Ui.Features.Toolbar.Menus.Items.ChangePassword.Dialog.Models;

public sealed class ChangePasswordModel
{
    [Required] public string OldPassword { get; set; } = string.Empty;

    [Required] public string NewPassword { get; set; } = string.Empty;

    [Required]
    [Compare(nameof(NewPassword))]
    public string ConfirmNewPassword { get; set; } = string.Empty;
}