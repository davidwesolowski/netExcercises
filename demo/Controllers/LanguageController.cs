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
    }
}