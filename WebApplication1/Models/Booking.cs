namespace WebApplication2.Models
{
    public class Booking
    {
        public int Id { get; set; }
        // public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime SelectEventDate { get; set; }
        public TimeSpan SelectEventStartingTime { get; set; }
        public string SelectHotel { get; set; }
        public string SelectEvent { get; set; }
        public string SelectEventTiming { get; set; }
        public int TotalNumberOfGuests { get; set; }
    }
}