using HotelsBooking.Guests.Domain;
using HotelsBooking.Hotels.Domain;

namespace HotelsBooking.Bookings.Application.DTOs
{
    public class BookingReadDTO
    {
        public int Id { get; set; }
        public DateTime EntryDate { get; set; } = new DateTime();
        public DateTime DepartureDate { get; set; } = new DateTime();
        public string City { get; set; } = string.Empty;
        public int PeopleAmount { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public List<Guest> Guests { get; set; } = new List<Guest>();
        public DateTime CreatedAt { get; set; } = new DateTime();
        public DateTime ModifyDate { get; set; } = new DateTime();
    }
}
