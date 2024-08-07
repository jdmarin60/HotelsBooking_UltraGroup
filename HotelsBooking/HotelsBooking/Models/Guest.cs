using System.ComponentModel.DataAnnotations;

namespace ReservasHoteles.Models
{
    public class Guest
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public DateTime FechaNacimiento { get; set; } = new DateTime();

        [Required]
        public string Gender { get; set; } = string.Empty;

        [Required]
        public string DocumentType { get; set; } = string.Empty;

        [Required]
        public string DocumentNumber { get; set; } = string.Empty;
        
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public int BookingId { get; set; }
        public Booking Booking { get; set; }

        public EmergencyContact? EmergencyContact { get; set; }
        
        public DateTime CreatedAt { get; set; } = new DateTime();
        
        public DateTime ModifyDate { get; set; } = new DateTime();
    }
}
