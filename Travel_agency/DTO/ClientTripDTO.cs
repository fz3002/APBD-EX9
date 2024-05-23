namespace Travel_agency.DTO;

public record ClientTripDTO(string FirstName, string LastName, string Email, string Telephone, string Pesel, DateTime? PaymentDate);