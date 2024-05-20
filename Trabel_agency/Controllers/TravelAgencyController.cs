using Microsoft.AspNetCore.Mvc;

namespace Trabel_agency.Controllers;

[ApiController]
[Route("api/TrabelAgency")]
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
