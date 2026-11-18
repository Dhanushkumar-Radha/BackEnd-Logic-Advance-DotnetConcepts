using CinemaApi.Models;

namespace CinemaApi.Services;
public class CinemaService : ICinemaService
{
    private const string Rows = "ABCDE";
    private const string PremiumRows ="AB";
    private const int SeatsPerRow =10;
    private const int MaxSeatsPerBooking = 6;
    private const decimal PremiumPrice =250m;
    private const decimal StandardPrice =150m;
    private static readonly TimeSpan CancellationCutoff  = TimeSpan.FromHours(2);

    private static readonly IReadOnlyList<string> AllSeatCodes =
        Rows.SelectMany(row => Enumerable.Range(1, SeatsPerRow).Select(n => $"{row}{n}")).ToList();
    private static readonly HashSet<string> ValidSeatCodes = AllSeatCodes.ToHashSet();
    
    private readonly object _lock = new();
    private readonly IClock _clock;
    private readonly List<Show> _shows;
    private readonly List<Booking> _bookings = new();
     private int _nextBookingId = 1;

    public CinemaService(IClock clock)
    {
        _clock = clock;
        var now = clock.Now;
        _shows = new List<Show>
        {
            new Show(1, "The Matrix", now.AddDays(1).AddHours(18)),
            new Show(2, "Inception", now.AddDays(1).AddHours(21)),
            new Show(3, "Interstellar", now.AddDays(2).AddHours(19)),
        };
    }
    public IReadOnlyList<Show> Getshows()
    {
        lock (_lock)
        {
            return _shows.ToList();
        }
    }
    public ServiceResult<IReadOnlyList<SeatStatus>> GetSeats(int showId)
    {
        lock(_lock)
        {
            if(!ShowExists(showId))
            {
                return ServiceResult<IReadOnlyList<SeatStatus>>.Fail(ServiceErrorKind.NotFound, $"Show with ID {showId} not found.");
            }
            var booked = BookedSeatsForShow(showId);
            var seats = AllSeatCodes
                .Select(code => new SeatStatus(code, IsPremium(code), booked.Contains(code), PriceFor(code)))
                .ToList();        }
        return ServiceResult<IReadOnlyList<SeatStatus>>.Success(seats);
    }
    public ServiceResult<ShowOccupancy> GetOccupancy(int showId)
    {
        lock (_lock)
        {
              if(!ShowExists(showId))
            {
                return ServiceResult<IReadOnlyList<SeatStatus>>.Fail(ServiceErrorKind.NotFound, $"Show with ID {showId} not found.");
            }
            var total =AllSeatCodes.Count;
            var booked = BookedSeatsFor(showId).Count;
            var percent = Math.Round(booked * 100.0 / total, 1);

            return ServiceResult<ShowOccupancy>.Success(
                new ShowOccupancy(total, booked, total - booked, percent));        }
    }

}