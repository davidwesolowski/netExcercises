using System;
using demo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace demo.Controllers
{

    [Route("language")]
    public class LanguageController : Controller {

        private readonly IStringLocalizer<LanguageController> _localizer;

        public LanguageController(IStringLocalizer<LanguageController> localizer) {
            this._localizer = localizer;
        }

        [HttpGet("test")]
        public IActionResult CultureTest() {
            // bool found = this._localizer["SI.NET"].ResourceNotFound;
            return View();
        }

        [HttpPost("test")]
        public IActionResult CultureTestPost() {
            return RedirectToAction("CultureTest");
        }

        [HttpGet("other-check/{language:language}")]
        public IActionResult CultureTestRoute(String language) {
            return View("CultureTest");
        }

        [HttpGet("test-3")]
        public string CultureTestController() {
            return this._localizer["SI.NET"];
        }


        [HttpGet("form-test")]
        public IActionResult FormTest() {
            return View(new Product());
        }

        [HttpPost("form-test")]
        public IActionResult FormTest([Bind("id, Name, Price, Category")] Product product) {
            if(!ModelState.IsValid) {
                TempData["message"] = "Błąd w formularzu";
                return View("FormTest", product);
            }
            return RedirectToAction("FormTest");
        }

        [HttpGet("test-view-location")]
        public IActionResult AdditionalViewLocation() {
            return View();
        }

        [HttpGet("my-layout")]
        public IActionResult MyLayout() {
            return View();
        }

        [HttpGet("razor-test")]
        public IActionResult RazorTest() {
            return View();
        }
    }
}