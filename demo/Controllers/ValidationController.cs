using demo.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

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

        // [Route("submit")]
        // [HttpPost]
        // public IActionResult Submit(ExampleForm form)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return View(viewName: "Index", form);
        //     }

        //     if (form.File != null)
        //     {
        //         System.Console.WriteLine($"Wielkość pliku {form.File.Length}");
        //         System.Console.WriteLine($"Nazwa pliku {form.File.Name}");
        //     }
        //     // zapis 

        //     return RedirectToAction(nameof(Index));
        // }
        [Route("submit")]
        [HttpPost]
        public IActionResult Submit (ExampleForm form) {

            if (!ModelState.IsValid)
            {
                return View(viewName: "Index", form);
            }

            if (form.Files != null) {
                foreach (var file in form.Files)
                {
                    Task.Run(() => handleFile(file));
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task handleFile(IFormFile file) {
            if (file.Length > 0) {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Files", file.FileName);
                System.Console.WriteLine($"Plik {file.FileName}, rozmiar {file.Length}");
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
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