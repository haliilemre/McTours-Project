using McTours.Business.Services;
using McTours.VehicleMakes;
using Microsoft.AspNetCore.Mvc;

namespace McTours.WebApp.Controllers
{
    public class VehicleMakesController : Controller
    {
        private readonly VehicleMakeService _vehicleMakeService = new VehicleMakeService();

        public IActionResult Index()
        {
            var vehicleMakes = _vehicleMakeService.GetAll();

            return View(vehicleMakes);
        }

        // /VehicleMakes/Create
        public IActionResult Create()
        {
            return View();
        }

        // ViewData Kullanımı
        [HttpPost]
        public IActionResult Create(VehicleMakeDto vehicleMake)
        {
            var commandResult = _vehicleMakeService.Create(vehicleMake);

            if (commandResult.IsSuccess)
            {
                // TempData üzerindeki veriler, en az bir kez okunana kadar (get edilene kadar)
                // sunucuda muhafaza edilir. En az bir kez okunduğunda, Response tamamlandıktan
                // sonra silinir.
                TempData["ResultMessage"] = commandResult.Message;

                return RedirectToAction("Index");
            }
            else
            {
                // ViewData adından anlaşılacağı üzere doğrudan View ile ilgilidir. Eğer
                // bir action View() döndürüyorsa ViewData üzerindeki değerler View tarafında
                // okunabilir. Eğer action metodu View dışında başka bir result döndürüyorsa
                // (RedirectToAction, Content, Json vs..) ViewData muhafaza edilmez.

                // ViewData => Dictionary<string,object> tipinde
                // ViewData["ResultMessage"] = commandResult.Message;

                //ViewBag => dynamic tipinde.
                ViewBag.ResultMessage = commandResult.Message;

                // Aslında ViewData ile ViewBag nesneleri aynı nesneler
                // Sadece syntax'ı farklıdır.

                // ViewData("Key") = "Tsubasa" şeklinde set ettiğiniz bir değeri
                // ViewBag üzerinden var name = ViewBag.Key şeklinde okuyabilirsiniz.

                return View();
            }
        }

        public IActionResult Update(int id)
        {
            var vehicleMake = _vehicleMakeService.GetById(id);

            return View(vehicleMake);
        }

        [HttpPost]
        public IActionResult Update(VehicleMakeDto vehicleMake)
        {
            var commandResult = _vehicleMakeService.Update(vehicleMake);
            if (commandResult.IsSuccess)
            {
                TempData["ResultMessage"] = commandResult.Message;

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ResultMessage = commandResult.Message;
                return View(vehicleMake);
            }
        }

        [HttpPost]
        public IActionResult Delete(VehicleMakeDto vehicleMake)
        {
            var commandResult = _vehicleMakeService.Delete(vehicleMake);
            if (commandResult.IsSuccess)
            {
                TempData["SuccessMessage"] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ResultMessage"] = commandResult.Message;
                return RedirectToAction("Index");
            }
        }




        /* TempData Kullanımı
        [HttpPost]
        public IActionResult Create(VehicleMakeDto vehicleMake)
        {
            var commandResult = _vehicleMakeService.Create(vehicleMake);

            if (commandResult.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ResultMessage"] = commandResult.Message;
                return View();
            }
        }
        */

        /*[HttpPost] // Post olduğunu belirtmezsek url'e manuel olarak get işlemi yapabiliriz. O yüzden belirtilmeli.
        public IActionResult CreateConfirmed(VehicleMakeDto vehicleMake)
        {
            var result = _vehicleMakeService.Create(vehicleMake);

            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // ViewBag, ViewData, TempData
                // Bir view'a model dışında ekstra bilgi taşımanın yöntemleri.


                //TempData.Add("ResultMessage", result.Message);

                TempData["ResultMessage"] = result.Message;
                return RedirectToAction("Create");
            }
        }
        */

        /*public IActionResult CreateConfirmed()
        //{
        //    var makeName = Request.Form["name"];
        //    var vehicleMakeDto = new VehicleMakeDto()
        //    {
        //        Name = makeName,
        //    };

        //    _vehicleMakeService.Create(vehicleMakeDto);

        //    return new EmptyResult();
        //}
        */

        /*public IActionResult CreateConfirmed(IFormCollection formValue)
        //{
        //    var makeName = formValue["name"];
        //    var vehicleMakeDto = new VehicleMakeDto()
        //    {
        //        Name = makeName,
        //    };

        //    _vehicleMakeService.Create(vehicleMakeDto);

        //    return new EmptyResult();
        //}
        */

        /*public IActionResult CreateConfirmed(string name)
        //{
        //    var vehicleMakeDto = new VehicleMakeDto()
        //    {
        //        Name = name,
        //    };

        //    _vehicleMakeService.Create(vehicleMakeDto);

        //    return new EmptyResult();
        //}
        */

        // Doğrudan model olarak karşılamak


    }
}
