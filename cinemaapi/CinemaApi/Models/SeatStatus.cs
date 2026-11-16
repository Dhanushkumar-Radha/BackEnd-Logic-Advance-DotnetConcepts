namespace CinemaApi.Models;
public sealed record SeatStatus(
    String Code,
    bool Ispremium,
    bool IsBooked,
    decimal Price
);