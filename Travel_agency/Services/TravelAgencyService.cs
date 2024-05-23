using Travel_agency.DTO;
using Travel_agency.Repositories;

namespace Travel_agency.Services;

public class TravelAgencyService : ITravelAgencyService
{
    private readonly ITravelAgencyRepository _repository;

    public TravelAgencyService(ITravelAgencyRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> DeleteTrips(int idClient)
    {
        var clientTrips = await _repository.GetClientTrips(idClient);
        if (clientTrips >0)
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

