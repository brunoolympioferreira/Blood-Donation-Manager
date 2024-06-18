using BloodDonation.Application.Services.Address;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonation.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DonorController : ControllerBase
{
    [HttpGet("address/{cep}")]
    public async Task<IActionResult> GetAddress([FromServices] IAddressService service, string cep)
    {
        var result = await service.GetAddressByViaCep(cep);

        return Ok(result);
    }
}
