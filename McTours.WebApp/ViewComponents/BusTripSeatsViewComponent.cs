using McTours.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace McTours.WebApp.ViewComponents
{
    public class BusTripSeatsViewComponent : ViewComponent
    {
        private readonly BusTripService _busTripService = new BusTripService();
        public IViewComponentResult Invoke(int id)
        {
            var busTripSeats = _busTripService.GetBusTripSeats(id);

            return View();
        }
    }
}
