using Microsoft.AspNetCore.Mvc;
using Travel_agency.Services;

namespace Travel_agency.Controllers;

[ApiController]
[Route("api")]
public class TravelAgencyController : ControllerBase
{

    private readonly ITravelAgencyService _service;
    public TravelAgencyController(ITravelAgencyService service)
    {
        _service = service;
    }

    [HttpGet("trips")]
    public async Task<IActionResult> GetTrips(CancellationToken cancellationToken, [FromQuery] int page = 0, [FromQuery] int pageSize = 10)
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

    [HttpDelete("clients/{idClient:int}")]
    public async Task<IActionResult> DeleteTrips(int idClient, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _service.DeleteTrips(idClient);
            if (result == -1)
            {
                return BadRequest("Unable to delete. Client has reserved trips");
            }
            else if (result == 0)
            {
                return BadRequest("Client not found");
            }
            return Ok();
        }
        catch (TaskCanceledException)
        {
            throw;
        }
    }

    [HttpPost("trips/{idTrip:int}/clients")]
    public async Task<IActionResult> AddClientToTrip(ClientTripDTO )
}
