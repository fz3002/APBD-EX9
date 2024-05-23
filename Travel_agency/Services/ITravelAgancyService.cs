
using Travel_agency.DTO;

namespace Travel_agency.Services;

public interface ITravelAgencyService
{
    Task<PagedTripsDTO> GetTrips(int page, int pageSize);
}