using System.Net;
using Microsoft.FluentUI.AspNetCore.Components;

namespace Eventing.Web;

public class HttpToastErrorHandler(IToastService toastService) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await base.SendAsync(request, cancellationToken);
            if (!response.Headers.Contains(Constants.CustomHeaders.FallBackHeader)) return response;
            switch (response.StatusCode)
            {
                case  >= HttpStatusCode.InternalServerError:
                case HttpStatusCode.RequestTimeout:
                case HttpStatusCode.TooManyRequests:
                    toastService.ShowError("Please try again later.");
                    break;
            }
            return response;
        }
        catch
        {
            toastService.ShowError("Something went wrong.");
            throw;
        }
    }
}