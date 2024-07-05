using BloodDonation.Application.Services.BloodStock;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonation.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BloodStockController : ControllerBase
{
    [HttpGet("stock-report")]
    public async Task<IActionResult> StockReport([FromServices] IBloodStockService service)
    {
        var result = await service.StockReport();

        return Ok(result);
    }
}
