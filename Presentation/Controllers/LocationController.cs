using Domain.Dto.Input;
using Domain.Exceptions;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("Location")]
    [ApiController]
    public class LocationController : Controller
    {
        public LocationController(OfficeRentalService service)
        {
            _service = service;
        }

        private readonly OfficeRentalService _service;

        [HttpGet("GetLocations")]
        public IActionResult GetLocations()
        {
            try
            {
                return StatusCode(200, _service.GetLocations());
            }

            catch (Exception) { return StatusCode(500, "Internal Server Error"); }

        }

        [HttpPost("AddLocation")]
        public IActionResult AddLocation(AddLocationRequest location)
        {
            try
            {
                _service.AddLocation(location);
                return StatusCode(200);
            }
            catch (EmptyFieldException ex) { return StatusCode(400, ex.Message); }

            catch (ExistsExceptions ex) { return StatusCode(400, ex.Message); }

            catch (Exception) { return StatusCode(500, "Internal Server Error"); }

        }
    }
}
