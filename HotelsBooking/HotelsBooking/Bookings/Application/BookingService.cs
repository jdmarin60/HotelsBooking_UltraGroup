using AutoMapper;
using HotelsBooking.Bookings.Application.DTOs;
using HotelsBooking.Shared.Data;
using HotelsBooking.Shared.ViewModels;

namespace HotelsBooking.Bookings.Application
{
    public class BookingService : IBookingService
    {
        private BookingDbContext db { get; set; }
        private readonly IMapper mapper;

        public BookingService(BookingDbContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }


        public Task<PetitionResponse> Create(BookingDbContext context, BookingCreateDTO bookingCreateDTO)
        {
            return null;
        }

        public async Task<IEnumerable<PetitionResponse>> GetAll()
        {
            return null;
        }
    }
}
