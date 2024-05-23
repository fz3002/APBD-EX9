
using Travel_agency.DTO;
using Travel_agency.Models;

namespace Travel_agency.Repositories;

public interface ITravelAgencyRepository
{
    Task<int> AddClientToTrip(Client client, int idTrip, DateTime? paymentDate);
    Task<bool> CheckClientWithPeselExists(string pesel);
    Task<bool> CheckClientWithPeselInTrip(string pesel, int idTrip);
    Task<bool> CheckTripExists(int idTrip);
    Task<int> DeleteClient(int idClient);
    Task<int> GetAllTripsCount();
    Task<int> GetClientTrips(int idClient);
    Task<int> GetLastIDClient();
    Task<IEnumerable<TripDTO>> GetTrips(int page, int pageSize);
    Task<bool> ValidateTripDate(int idTrip);
}