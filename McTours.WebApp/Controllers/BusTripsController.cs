using McTours.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace McTours.WebApp.Controllers
{
    public class BusTripsController : Controller
    {
        private readonly BusTripService _busTripService = new BusTripService();

        // BusTrips/1/Tickets
        [Route("[controller]/{id}/[action]")]
        public IActionResult Tickets(int id)
        {
            var busTripSummary = _busTripService.GetSummaryById(id);
            return View(busTripSummary);
        }
    }
}
