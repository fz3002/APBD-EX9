using Microsoft.EntityFrameworkCore;
using Travel_agency.DTO;
using Travel_agency.Models;

namespace Travel_agency.Repositories;

public class TravelAgencyRepository : ITravelAgencyRepository
{
    private readonly TravelAgencyContext _context = new TravelAgencyContext();

    public async Task<int> GetAllTripsCount()
    {
        return await _context.Trips.CountAsync();
    }

    public async Task<IEnumerable<TripDTO>> GetTrips(int page, int pageSize)
    {
        var paged = await _context.Trips
                            .Include(x => x.ClientTrips)
                            .ThenInclude(ct => ct.IdClientNavigation)
                            .Include(x => x.IdCountries)
                            .Include(x => x.ClientTrips)
                            .OrderByDescending(x => x.DateFrom)
                            .Skip((page - 1)*pageSize)
                            .Take(pageSize)
                            .ToListAsync();
        
        var result = paged.Select(c => new TripDTO
        (
            c.Name,
            c.Description,
            c.DateFrom,
            c.DateTo,
            c.MaxPeople,
            c.IdCountries.Select(c => new CountryDTO(c.Name)),
            c.ClientTrips.Select(c => new ClientDTO(c.IdClientNavigation.FirstName, c.IdClientNavigation.LastName))
        ));

        return result;
    }
}