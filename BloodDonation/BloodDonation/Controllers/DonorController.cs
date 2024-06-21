using BloodDonation.Application.Models.InputModels.Donor;
using BloodDonation.Application.Services.Address;
using BloodDonation.Application.Services.Donor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonation.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class DonorController : ControllerBase
{
    [HttpGet("address/{cep}")]
    public async Task<IActionResult> GetAddress([FromServices] IAddressService service, string cep)
    {
        var result = await service.GetAddressByViaCep(cep);

        return Ok(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromServices] IDonorService service, [FromBody] DonorInputModel model)
    {
        var result = await service.Create(model);

        return Ok(result);
    }
}
