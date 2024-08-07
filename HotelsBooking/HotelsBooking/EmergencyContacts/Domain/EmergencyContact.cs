using HotelsBooking.Guests.Domain;
using System.ComponentModel.DataAnnotations;

namespace HotelsBooking.EmergencyContacts.Domain
{
    public class EmergencyContact
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public int GuestId { get; set; }
        public Guest Guest { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = new DateTime();

        public DateTime ModifyDate { get; set; } = new DateTime();
    }
}
