﻿using BloodDonation.Application.Models.InputModels.Donation;
using BloodDonation.Application.Services.Donation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonation.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class DonationController : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromServices] IDonationService service, [FromBody] DonationInputModel model)
    {
        var result = await service.Register(model);
        return Ok(result);
    }

    [HttpGet("{donorId}")]
    public async Task<IActionResult> GetDonationByDonorId([FromServices] IDonationService service, Guid donorId)
    {
        var result = await service.GetByDonor(donorId);
        return Ok(result);
    }

    [HttpGet()]
    public async Task<IActionResult> GetDonationByDonorId([FromServices] IDonationService service)
    {
        var result = await service.GetAll();
        return Ok(result);
    }
}
