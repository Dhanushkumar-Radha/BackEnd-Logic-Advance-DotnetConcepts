namespace CinemaApi.Models;
public enum BookingStatus
{
    Confirmed,
    Cancelled,

}

public sealed record Booking(
    int Id,
    int ShowId,
    string CustomerName,
    IReadOnlyList<string> Seats,
    decimal TotalAmount,
    BookingStatus Status
);