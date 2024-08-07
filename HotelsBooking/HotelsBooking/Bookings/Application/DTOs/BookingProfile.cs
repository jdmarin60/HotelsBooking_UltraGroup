using HotelsBooking.Bookings.Domain;
using AutoMapper;

namespace HotelsBooking.Bookings.Application.DTOs
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingReadDTO>();
            CreateMap<BookingCreateDTO, Booking>();
        }
    }
}
