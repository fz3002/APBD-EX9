using Travel_agency.DTO;
using Travel_agency.Models;
using Travel_agency.Repositories;

namespace Travel_agency.Services;

public class TravelAgencyService : ITravelAgencyService
{
    private readonly ITravelAgencyRepository _repository;

    public TravelAgencyService(ITravelAgencyRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> AddClientToTrip(int idTrip, ClientTripDTO clientToAdd)
    {
        var clientWithPeselExists = await _repository.CheckClientWithPeselExists(clientToAdd.Pesel);
        if (clientWithPeselExists) return -1;
        var tripExists = await _repository.CheckTripExists(idTrip);
        if (!tripExists) return -3;
        var clientWithPeselInTrip = await _repository.CheckClientWithPeselInTrip(clientToAdd.Pesel, idTrip);
        if (clientWithPeselInTrip) return -2;
        var validateTripDate = await _repository.ValidateTripDate(idTrip);
        if (!validateTripDate) return -4;
        int idClient = await _repository.GetLastIDClient() + 1;
        Client client = new Client
        {
            IdClient = idClient,
            FirstName = clientToAdd.FirstName,
            LastName = clientToAdd.LastName,
            Email = clientToAdd.Email,
            Telephone = clientToAdd.Telephone,
            Pesel = clientToAdd.Pesel
        };
        return await _repository.AddClientToTrip(client, idTrip, clientToAdd.PaymentDate);
    }

    public async Task<int> DeleteTrips(int idClient)
    {
        var clientTrips = await _repository.GetClientTrips(idClient);
        if (clientTrips > 0)
        {
            return -1;
        }
        return await _repository.DeleteClient(idClient);
    }

    public async Task<PagedTripsDTO> GetTrips(int page1, int pageSize)
    {
        var trips = await _repository.GetTrips(page1, pageSize);
        var allPages = await _repository.GetAllTripsCount();
        return new PagedTripsDTO(page1, pageSize, allPages, trips);
    }
}

