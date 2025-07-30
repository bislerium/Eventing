using System.Text.Json;
using Eventing.Web.Features.Login.Models;
using Microsoft.AspNetCore.Components;

namespace Eventing.Web.Features.Login;

public partial class LoginPage(NavigationManager navigationManager) : ComponentBase
{
    [SupplyParameterFromForm]
    private LoginModel LoginModel { get; set; } = new();

    private async Task SubmitAsync()
    {
        Console.WriteLine(JsonSerializer.Serialize(LoginModel));
        navigationManager.NavigateTo("/home");
    }
}