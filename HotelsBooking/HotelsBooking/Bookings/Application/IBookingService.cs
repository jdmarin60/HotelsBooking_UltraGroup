using HotelsBooking.Bookings.Application.DTOs;
using HotelsBooking.Shared.Data;
using HotelsBooking.Shared.ViewModels;

namespace HotelsBooking.Bookings.Application
{
    public interface IBookingService
    {
        Task<PetitionResponse> Create(BookingDbContext context, BookingCreateDTO bookingCreateDTO);
        Task<IEnumerable<PetitionResponse>>  GetAll();
    }
}
