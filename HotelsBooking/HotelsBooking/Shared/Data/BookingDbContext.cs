using HotelsBooking.Bookings.Domain;
using HotelsBooking.EmergencyContacts.Domain;
using HotelsBooking.Guests.Domain;
using HotelsBooking.Hotels.Domain;
using HotelsBooking.Rooms.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotelsBooking.Shared.Data
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
