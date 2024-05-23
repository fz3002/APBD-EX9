
using Travel_agency.DTO;

namespace Travel_agency.Repositories;

public interface ITravelAgencyRepository
{
    Task<int> DeleteClient(int idClient);
    Task<int> GetAllTripsCount();
    Task<int> GetClientTrips(int idClient);
    Task<IEnumerable<TripDTO>> GetTrips(int page, int pageSize);
}