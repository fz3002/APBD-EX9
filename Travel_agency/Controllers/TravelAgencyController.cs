using Microsoft.AspNetCore.Mvc;
using Travel_agency.Services;

namespace Travel_agency.Controllers;

[ApiController]
[Route("api/trips")]
public class TravelAgencyController : ControllerBase
{

    private readonly ITravelAgencyService _service;
    public TravelAgencyController(ITravelAgencyService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetTrips(CancellationToken cancellationToken, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        try
        {
            var returnQuery = await _service.GetTrips(page, pageSize);
            return Ok(returnQuery);
        }
        catch (TaskCanceledException)
        {
            throw;
        }

    }
}
