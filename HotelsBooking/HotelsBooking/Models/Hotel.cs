using System.ComponentModel.DataAnnotations;

namespace ReservasHoteles.Models
{
    public class Hotel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public bool Enable { get; set; }

        [Required]
        public string Address { get; set; } = string.Empty;
        
        [Required]
        public bool Qualification { get; set; }

        public List<Room> Rooms { get; set; } = new List<Room>();
        public List<Booking> Bookings { get; set; } = new List<Booking>();
        public DateTime CreatedAt { get; set; } = new DateTime();
        public DateTime ModifyDate { get; set; } = new DateTime();
    }
}
