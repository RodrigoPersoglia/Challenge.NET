using Domain.Dto.Input;
using Domain.Exceptions;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("Booking")]
    [ApiController]
    public class BookingController : Controller
    {
        public BookingController(OfficeRentalService service)
        {
            _service = service;
        }

        private readonly OfficeRentalService _service;


        [HttpPost("BookOffice")]
        public IActionResult BookOffice(BookOfficeRequest request)
        {
            try
            {
                _service.BookOffice(request);
                return StatusCode(200);
            }
            catch (NotExistsUserExceptions ex) { return StatusCode(404, ex.Message); }

            catch (NotExistsLocationExceptions ex) { return StatusCode(404, ex.Message); }

            catch (ExistsExceptions ex) { return StatusCode(404, ex.Message); }

            catch (ReservedException ex) { return StatusCode(400, ex.Message); }

            catch (Exception) { return StatusCode(500, "Internal Server Error"); }


        }


        [HttpGet("GetBookings")]
        public IActionResult GetBookings(string locationName, string officeName)
        {
            try
            {
                return StatusCode(200, _service.GetBookings(locationName, officeName));
            }
            catch (NotExistsLocationExceptions ex) { return StatusCode(404, ex.Message); }

            catch (NotExistsOfficeExceptions ex) { return StatusCode(404, ex.Message); }

            catch (Exception) { return StatusCode(500, "Internal Server Error"); }

        }
    }
}
