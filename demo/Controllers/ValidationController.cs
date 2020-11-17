using demo.Domain;
using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers
{
    [Route("/validation")]
    public class ValidationController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View(new ExampleForm());
        }

        [Route("submit")]
        [HttpPost]
        public IActionResult Submit(ExampleForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(viewName: "Index", form);
            }

            if (form.File != null)
            {
                System.Console.WriteLine($"Wielkość pliku {form.File.Length}");
                System.Console.WriteLine($"Nazwa pliku {form.File.Name}");
            }
            // zapis 

            return RedirectToAction(nameof(Index));
        }

        [Route("self-form")]
        public IActionResult SelfValidatableFormAction()
        {
            return View(new SelfValidatableForm());
        }

        [HttpPost]
        [Route("self-form")]
        public IActionResult SelfValidatableFormAction(SelfValidatableForm form)
        {
            if (!ModelState.IsValid)
            {
                return View("SelfValidatableFormAction", form);
            }

            return RedirectToAction(nameof(SelfValidatableFormAction));
        }

        [AcceptVerbs("GET", "POST")]
        [Route("check-country")]
        public IActionResult CheckCountry(string country)
        {
            if (country != "Polska" && country != "Niemcy")
            {
                return Json("Niepoprawna nazwa kraju");
                
            }

            return Json(true);
        }

        [Route("check-user-exists")]
        public IActionResult UserExists(string Name, string Surname)
        {
            if (Name == "Jan" && Surname == "Kowalski")
            {
                return Json("Użytkownik o podanym imieniu i nazwisku już istnieje");
            }

            return Json(true);
        }
    }
}