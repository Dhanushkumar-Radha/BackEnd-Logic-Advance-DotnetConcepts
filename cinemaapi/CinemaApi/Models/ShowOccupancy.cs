public sealed record ShowOccupancy(
    int TotalSeats,
    int BookedSeats,
    int AvailableSeats,
    double OccupancyPercentage
);