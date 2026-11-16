public class CreateBookingRequest
{
    public int showId { get; set; }
    public string CustomerName { get; set; } =string.Empty;
    public List<String> Seats { get; set; } = [];
}