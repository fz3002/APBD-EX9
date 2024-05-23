namespace Travel_agency.DTO;

public record PagedTripsDTO(int PageNum, int PageSize, int AllPages, IEnumerable<TripDTO> Trips);