using HotelsBooking.Guests.Domain;
using HotelsBooking.Hotels.Domain;
using System.ComponentModel.DataAnnotations;

namespace HotelsBooking.Bookings.Domain
{
    public class Booking
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public DateTime EntryDate { get; set; } = new DateTime();

        public DateTime DepartureDate { get; set; } = new DateTime();

        [Required]
        public string City { get; set; } = string.Empty;

        [Required]
        public int PeopleAmount { get; set; }

        [Required]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public List<Guest> Guests { get; set; } = new List<Guest>();

        public DateTime CreatedAt { get; set; } = new DateTime();

        public DateTime ModifyDate { get; set; } = new DateTime();
    }
}
