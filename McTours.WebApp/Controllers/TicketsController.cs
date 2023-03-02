using McTours.Business;
using McTours.Business.Services;
using McTours.Tickets;
using McTours.WebApp.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace McTours.WebApp.Controllers
{
    public class TicketsController : Controller
    {
        private readonly TicketService _ticketService = new TicketService();
        private readonly PassengerService _passengerService = new PassengerService();
        private readonly BusTripService _busTripService = new BusTripService();

        public IActionResult Index()
        {

            return View();
        }


        [HttpPost]
        public IActionResult BusTripTicketCreate(int busTripId, int seatNumber, int passengerId)
        {
            var busTrip = _busTripService.GetById(busTripId);
            var passenger = _passengerService.GetById(passengerId);

            var ticketReview = new TicketReview()
            {
                BusTripId = busTripId,
                SeatNumber = seatNumber,
                PassengerId = passengerId,
                Price = busTrip.TicketPrice,
                PassengerFirstName = passenger.FirstName,
                PassengerLastName = passenger.LastName,
            };

            return PartialView(ticketReview);
        }

        public IActionResult Create(TicketDto ticketDto)
        {
            var result = _ticketService.Create(ticketDto);

            if (result.IsSuccess)
            {
                TempData[Keys.SuccessMessage] = result.Message;
            }
            else
            {
                TempData[Keys.ErrorMessage] = result.Message;
            }
            return RedirectToAction("Tickets", "BusTrips", new { id = ticketDto.BusTripId });
        }
    }
}
