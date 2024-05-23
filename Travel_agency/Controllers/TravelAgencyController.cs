using Microsoft.AspNetCore.Mvc;
using Travel_agency.DTO;
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
    public async Task<IActionResult> AddClientToTrip(int idTrip, ClientTripDTO clientToAdd, CancellationToken cancellationToken)
    {
        try
        {
           var result = await _service.AddClientToTrip(idTrip, clientToAdd);
           if (result == -1)
            {
                return BadRequest("Client with this Pesel Already Exists");
            }
            else if (result == -2)
            {
                return BadRequest("Client with this Pesel is already added to this trip");
            }
            else if (result == -3)
            {
                return BadRequest("Trip doesn't exist");
            }
            else if (result == -4)
            {
                return BadRequest("Trip has already happened");
            }
            else if (result == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }
        catch (TaskCanceledException)
        {
            throw;
        }
    }
}
