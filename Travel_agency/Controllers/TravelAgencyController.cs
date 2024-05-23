using Microsoft.AspNetCore.Mvc;

namespace Travel_agency.Controllers;

[ApiController]
[Route("api/trips")]
public class TravelAgencyController : ControllerBase
{

    public TravelAgencyController()
    {
        
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        
    }
}
