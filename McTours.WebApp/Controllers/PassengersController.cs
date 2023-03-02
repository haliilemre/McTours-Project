using McTours.Business.Services;
using McTours.Passengers;
using Microsoft.AspNetCore.Mvc;

namespace McTours.WebApp.Controllers
{
    public class PassengersController : Controller
    {
        private readonly PassengerService _passengerService = new PassengerService();

        public IActionResult Index()
        {
            return View();
        }

        // Passengers/SearchPassengers
        public IActionResult SearchPassengers()
        {
            return PartialView();
            // Partial View => Layout'u olmadan Vıew'ı response et
        }
        [HttpPost]
        public IActionResult SearchPassengers(SearchPassengerDto searchPassengerDto)
        {
            var passengers = _passengerService.SearchPassengers(searchPassengerDto);

            return Json(passengers);
        }
    }
}
