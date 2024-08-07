using HotelsBooking.Bookings.Application;
using HotelsBooking.Bookings.Application.DTOs;
using HotelsBooking.Shared.Data;
using HotelsBooking.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HotelsBooking.Bookings.Infrastructure
{
    [Route("[Controller]")]
    public class BookingController : ControllerBase 
    {
        private BookingDbContext _context;
        private IBookingService _bookingService;

        public BookingController(BookingDbContext context, IBookingService bookingService)
        {
            _context = context;
            _bookingService = bookingService;
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> Create(BookingCreateDTO bookingCreateDTO)
        {
            try
            {
                PetitionResponse response = await _bookingService.Create(_context, bookingCreateDTO);
                if (!response.Success)
                    return BadRequest(new { message = response.Message });

                return Ok(response.Result);
            }
            catch (Exception ex)
            {
                Log.Error($"{ex}");
                return BadRequest(ex.Message);
            }
        }
    }
}
