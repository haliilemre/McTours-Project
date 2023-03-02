using McTours.Business.Services;
using McTours.DataAccess;
using McTours.VehicleDefinitions;
using McTours.WebApp.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace McTours.WebApp.Controllers
{
    public class VehicleDefinitionsController : Controller
    {
        private readonly VehicleDefinitionService _definitionService = new VehicleDefinitionService();
        private readonly VehicleMakeService _makeService = new VehicleMakeService();
        private readonly VehicleModelService _modelService = new VehicleModelService();


        McToursContext _context = new McToursContext();


        public IActionResult Index()
        {
            var vehDefinitions = _definitionService.GetSummaries();
            return View(vehDefinitions);
        }


        public IActionResult Create()
        {
            LoadExtraModels();

            return View();
        }

        internal void LoadExtraModels()
        {
            ViewBag.FuelTypes = new SelectList(EnumHelper.FuelTypesGetAll(), "Value", "Name");
            ViewBag.SeatingTypes = new SelectList(EnumHelper.SeatingTypesGetAll(), "Value", "Name");
            ViewBag.Utilities = EnumHelper.UtilityGetAll();

            var vehMakes = _makeService.GetAll();
            ViewBag.VehicleMakes = new SelectList(vehMakes, "Id", "Name");

            var vehModels = _modelService.GetAll();
            ViewBag.VehicleModels = new SelectList(vehModels, "Id", "Name");
        }

        [HttpPost]
        public IActionResult Create(VehicleDefinitionDto vehicleDefinition)
        {
            LoadExtraModels();

            var commandResult = _definitionService.Create(vehicleDefinition);

            if (commandResult.IsSuccess)
            {
                TempData[Keys.SuccessMessage] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {
                TempData.Add(Keys.ErrorMessage, commandResult.Message);
                return View(vehicleDefinition);
            }
        }

        public IActionResult Update(int id)
        {
            var vehDefinition = _definitionService.GetById(id);

            if (vehDefinition != null)
            {
                LoadExtraModels();

                return View(vehDefinition);
            }
            else
            {
                ViewData[Keys.ErrorMessage] = $"{id} ID'li Kayıt Bulunamadı!";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Update(VehicleDefinitionDto vehDefinition)
        {
            var result = _definitionService.Update(vehDefinition);

            if (result.IsSuccess)
            {
                ViewData[Keys.SuccessMessage] = result.Message;
                return RedirectToAction("Index");
            }
            else
            {
                LoadExtraModels();

                ViewData[Keys.ErrorMessage] = result.Message;
                return View(vehDefinition);
            }
        }

        [HttpPost]
        public IActionResult Delete(VehicleDefinitionDto vehDefinition)
        {
            var commandResult = _definitionService.Delete(vehDefinition);

            if (commandResult.IsSuccess)
            {
                TempData[Keys.SuccessMessage] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {
                TempData[Keys.ErrorMessage] = commandResult.Message;
                return RedirectToAction("Index");
            }
        }

        public JsonResult GetModels(int id) // gönderilen make id'ye göre işlem yapacağız
        {
            //var models = (from model in _context.VehicleModels
            //              join make in _context.VehicleMakes on model.Id equals make.Id
            //              where model.VehicleMake.Id == id
            //              select new
            //              {
            //                  Text = model.Name,
            //                  Value = model.Id.ToString(),
            //              }).ToList();

            var models = _modelService.GetAll();
            var selectList = models.Where(x => x.VehicleMakeId == id).ToList();

            return Json(selectList);
        }
    }
}
