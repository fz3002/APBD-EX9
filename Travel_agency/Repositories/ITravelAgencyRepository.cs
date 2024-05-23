
using Travel_agency.DTO;

namespace Travel_agency.Repositories;

public interface ITravelAgencyRepository
{
    Task<int> GetAllTripsCount();
    Task<IEnumerable<TripDTO>> GetTrips(int page, int pageSize);
}