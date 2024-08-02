using JWT_Application.DTO.Request;
using JWT_Application.Implementetion.Jwt_Web_Token;
using JWT_Application.Implementetion.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        public readonly IJWTService _jWTService;
        public readonly IBookingService _bookingService;


        public BookingController(IBookingService bookingService, IJWTService jWTService) 
        {
            _bookingService = bookingService;
            _jWTService = jWTService;
        }
        [HttpPut("create-booking")]
        public async Task<IActionResult> CreateBooking(CreateBooking request)
        {
            var booking = await _bookingService.CreateBooking(request);
            if(booking.Success == false)
            {
                return Ok(booking);
            }
            else
            {
                return BadRequest(booking);
            }
        }

        [HttpPost("update-booking/{Id}")]
        public async Task<IActionResult> UpdateBooking (Guid Id, UpdateBooking request)
        {
            var booking = await _bookingService.UpdateBookingAsync(Id, request);
            if(booking.Success == false)
            {
                return Ok(booking);
            }
            else
            {
                return BadRequest(booking);
            }
        }

        [HttpDelete("delete-booking/{Id}")]
        public async Task<IActionResult> DeleteBooking(Guid Id)
        {
            var booking = await _bookingService.DeleteBookingAsync(Id);
            if(booking.Success == false)
            {
                return Ok(booking);
            }
            return BadRequest(booking);
        }

        [HttpGet("get-all-booking")]
        public async Task<IActionResult> GetAllBooking()
        {
            var booking = await _bookingService.GetAllBookingAsync();
            if(booking.Success == false)
            {
                return Ok(booking);
            }
            else
            {
                return BadRequest(booking);
            }
        }

        [HttpGet("get-all-booking-by-id/{Id}")]
        public async Task<IActionResult> GetAllBookingById(Guid Id)
        {
            var booking = await _bookingService.GetAllBookingById(Id);
            if (booking.Success == false)
            { 
                return Ok(booking); 
            }
            else
            {
                return BadRequest(booking);
            }
        }
    }
}
