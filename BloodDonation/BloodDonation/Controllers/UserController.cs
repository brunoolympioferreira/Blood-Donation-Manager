using BloodDonation.Application.Models.InputModels.User;
using BloodDonation.Application.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonation.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> AddAsync([FromServices] IUserService service, [FromBody] UserInputModel model)
    {
        var result = await service.AddAsync(model);

        return Ok(result);
    }
}
