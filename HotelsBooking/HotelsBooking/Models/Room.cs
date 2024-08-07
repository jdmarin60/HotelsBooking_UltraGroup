using System.ComponentModel.DataAnnotations;

namespace ReservasHoteles.Models
{
    public class Room
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; } = string.Empty;
        
        [Required]
        public bool Location { get; set; }
        
        [Required]
        public bool Enable { get; set; }
        
        [Required]
        public int  Cost { get; set; }
        
        [Required]
        public int Taxes { get; set; }

        [Required]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }


        public DateTime CreatedAt { get; set; } = new DateTime();
        public DateTime ModifyDate { get; set; } = new DateTime();
    }
}
