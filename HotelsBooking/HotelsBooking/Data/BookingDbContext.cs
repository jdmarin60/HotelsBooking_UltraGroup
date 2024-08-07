using Microsoft.EntityFrameworkCore;
using ReservasHoteles.Models;
using System;

namespace HotelsBooking.Data
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> opt) : base(opt)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }
    }
}
