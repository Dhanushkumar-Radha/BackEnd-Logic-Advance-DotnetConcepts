using CinemaApi.Models;

namespace CinemaApi.Services;
public interface ICinemaService
{
    IReadOnlyList<Show> GetShows();
    ServiceResult<IReadOnlyList<SeatStatus>> GetSeats(int showId);
    ServiceResult<ShowOccupancy> GetOccupancy(int showId);

    ServiceResult<Booking> CreateBooking(int showId, string customerName, IReadOnlyList<string> seats);
    ServiceResult<Booking> GetBooking(int bookingId);
    ServiceResult<Booking> CancelBooking(int bookingId);
}