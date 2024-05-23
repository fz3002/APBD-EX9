namespace Travel_agency.DTO;

public record TripDTO(string Name, string Description, DateTime? DateFrom, DateTime? DateTo, int MaxPeople, IEnumerable<CountryDTO> Countries, IEnumerable<ClientDTO> Clients);