using Microsoft.AspNetCore.Mvc;

namespace Eventing.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiBaseController : ControllerBase;