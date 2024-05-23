
using Travel_agency.DTO;

namespace Travel_agency.Services;

public interface ITravelAgencyService
{
    Task<int> AddClientToTrip(int idTrip, ClientTripDTO clientToAdd);
    Task<int> DeleteTrips(int idClient);
    Task<PagedTripsDTO> GetTrips(int page, int pageSize);
}