namespace CinemaApi.Models;
public sealed record Show(
    int Id,
    string Title,
    DateTime StartsAt
);