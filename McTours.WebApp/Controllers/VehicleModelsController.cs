using McTours.Business.Services;
using McTours.DataAccess;
using McTours.VehicleModels;
using McTours.WebApp.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace McTours.WebApp.Controllers
{
    public class VehicleModelsController : Controller
    {
        private readonly VehicleModelService _vehicleModelService = new VehicleModelService();
        private readonly VehicleMakeService _vehicleMakeService = new VehicleMakeService();
        McToursContext context = new McToursContext();


        public IActionResult Index()
        {
            var vehicleModels = _vehicleModelService.GetSummaries();

            return View(vehicleModels);
        }

        public IActionResult Create()
        {
            ViewBag.VehicleMakes = _vehicleMakeService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(VehicleModelDto vehicleModel)
        {
            if (vehicleModel.Name == null)
            {
                ViewBag.VehicleMakes = _vehicleMakeService.GetAll();
            }

            var commandResult = _vehicleModelService.Create(vehicleModel);

            if (commandResult.IsSuccess)
            {
                TempData[Keys.SuccessMessage] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {
                TempData.Add(Keys.ErrorMessage, commandResult.Message);
                return View(vehicleModel);
            }
        }
        
        public IActionResult Update(int id)
        {
            var vehicleModel = _vehicleModelService.GetById(id);

            if (vehicleModel != null)
            {
                var vehicleMakes = _vehicleMakeService.GetAll();
                ViewBag.VehicleMakes = new SelectList(vehicleMakes, "Id", "Name");

                return View(vehicleModel);
            }
            else
            {
                ViewData[Keys.ErrorMessage] = $"{id} ID'li Kayıt Bulunamadı!";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Update(VehicleModelDto vehicleModel)
        {
            var result = _vehicleModelService.Update(vehicleModel);

            if (result.IsSuccess)
            {
                ViewData[Keys.SuccessMessage] = result.Message;
                return RedirectToAction("Index");
            }
            else
            {
                var vehicleMakes = _vehicleMakeService.GetAll();
                ViewBag.VehicleMakes = new SelectList(vehicleMakes, "Id", "Name");
                ViewData[Keys.ErrorMessage] = result.Message;
                return View(vehicleModel);
            }
        }


        [HttpPost]
        public IActionResult Delete(VehicleModelDto vehicleModel)
        {
            var commandResult = _vehicleModelService.Delete(vehicleModel);

            if (commandResult.IsSuccess)
            {
                ViewData[Keys.SuccessMessage] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {
                ViewData[Keys.ErrorMessage] = commandResult.Message;
                return RedirectToAction("Index");
            }
        }

    }
}
