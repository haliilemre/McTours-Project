using McTours.Business.Services;
using McTours.Vehicles;
using McTours.WebApp.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace McTours.WebApp.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly VehicleService _vehicleService = new VehicleService();
        private readonly VehicleDefinitionService _vehicleDefinitionService = new VehicleDefinitionService();
        private readonly VehicleModelService _vehicleModelService = new VehicleModelService();
        private readonly VehicleMakeService _vehicleMakeService = new VehicleMakeService();
        public IActionResult Index()
        {
            var vehicles = _vehicleService.GetSummaries();
            return View(vehicles);
        }
        public IActionResult Create()
        {
            //Selectlist ile göndermek önemli bu şekilde gönderince farklı entitiy sınıflarındaki id ve value namelerini işlem yaptığım model cshtml
            //tarafında listeleme imkanım oluyor. Burada definiton'ı Id parametresiyle VehicleDto model tipindeki cshtml create tarafında entityde olan navigation
            //propertye aktarabiliyorum. asp-for da dtoda bulunan navigation property ismimi alıyorum asp-itemsdaki ViewBag ile SelectList gelen nesnedeki işaretli olan
            //Id ile eşliyorum. Görüntüleme kısmına ise Value gönderiyorum yani Definitions
            ViewBag.Definitions = new SelectList(_vehicleService.GetByNameDefinition(), "Id", "Definitions");
            return View(new VehicleDto() { RegistrationDate = DateTime.Now });
        }
        [HttpPost]
        public IActionResult Create(VehicleDto vehicleDto)
        {
            var commandResult = _vehicleService.Create(vehicleDto);
            if (commandResult.IsSuccess)
            {
                TempData[Keys.SuccessMessage] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Definitions = new SelectList(_vehicleService.GetByNameDefinition(), "Id", "Definitions");
                TempData[Keys.ErrorMessage] = commandResult.Message;
                return View(vehicleDto);
            }
        }
        public IActionResult Update(int id)
        {
            var vehicle = _vehicleService.GetById(id);
            if (vehicle != null)
            {
                ViewBag.Definitions = new SelectList(_vehicleService.GetByNameDefinition(), "Id", "Definitions");
                return View(vehicle);
            }
            else
            {
                TempData["ErrorMessage"] = $"{id} ID'li kayıt bulunamadı";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Update(VehicleDto vehicle)
        {
            var commandResult = _vehicleService.Update(vehicle);

            if (commandResult.IsSuccess)
            {
                TempData["SuccessMessage"] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Definitions = new SelectList(_vehicleService.GetByNameDefinition(), "Id", "Definitions");
                ViewData[Keys.ErrorMessage] = commandResult.Message;
                return View(vehicle);
            }
        }
        public IActionResult Delete(int id)
        {
            var vehicleDefinition = _vehicleService.GetById(id);
            if (vehicleDefinition != null)
            {
                ViewBag.Definitions = new SelectList(_vehicleService.GetByNameDefinition(), "Id", "Definitions");
            }
            else
            {
                TempData["ErrorMessage"] = $"{id} ID'li kayıt bulunamadı !";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(VehicleDto vehicle)
        {
            var commandResult = _vehicleService.Delete(vehicle);
            if (commandResult.IsSuccess)
            {
                TempData[Keys.SuccessMessage] = commandResult.Message;
            }
            else
            {
                TempData[Keys.ErrorMessage] = commandResult.Message;
            }
            return RedirectToAction("Index");
        }
    }
}
