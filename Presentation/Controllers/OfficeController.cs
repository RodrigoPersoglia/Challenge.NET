using Domain.Dto.Input;
using Domain.Exceptions;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("Office")]
    [ApiController]
    public class OfficeController : Controller
    {
        public OfficeController(OfficeRentalService service)
        {
            _service = service;
        }

        private readonly OfficeRentalService _service;

        [HttpPost("AddOffice")]
        public IActionResult AddOffice(AddOfficeRequest request)
        {
            try
            {
                _service.AddOffice(request);
                return StatusCode(200);
            }
            catch (EmptyFieldException ex) { return StatusCode(400, ex.Message); }

            catch (ZeroCapacityException ex) { return StatusCode(400, ex.Message); }

            catch (NotExistsLocationExceptions ex) { return StatusCode(404, ex.Message); }

            catch (ExistsOfficeExceptions ex) { return StatusCode(400, ex.Message); }

            catch (Exception) { return StatusCode(500, "Internal Server Error"); }

        }


        [HttpGet("GetOffices")]
        public IActionResult GetOffices(string locationName)
        {
            try
            {
                return StatusCode(200, _service.GetOffices(locationName));
            }
            catch (NotExistsLocationExceptions ex) { return StatusCode(400, ex.Message); }

            catch (Exception) { return StatusCode(500, "Internal Server Error"); }

        }


        [HttpPost("GetOfficeSuggestion")]
        public IActionResult GetOfficeSuggestions(SuggestionsRequest request)
        {
            return StatusCode(200, _service.GetOfficeSuggestions(request));
        }

    }
}
