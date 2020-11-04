using demo.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace demo.Controllers
{
    [Route("/template")]
    public class TemplateController : Controller
    {
        private ILogger<TemplateController> _logger;

        public TemplateController(ILogger<TemplateController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogCritical("Obsługuję ąkcję Index w kontrolerze Template");
            return View();
        }

        [Route("with-layout")]
        public IActionResult WithLayout()
        {
            return View();
        }

        [Route("helpers")]
        public IActionResult TestHtmlHelper()
        {
            return View(new ExampleFormViewModel());
        }

        [Route("helpers")]
        [HttpPost]
        public IActionResult TestHtmlHelperSubmit(ExampleForm form)
        {
            _logger.LogCritical(form.ToString());
            return RedirectToAction(nameof(TestHtmlHelper));
        }

        [Route("ui-helper")]
        public IActionResult TestUIHelper()
        {
            UserProfile profile = new UserProfile();
            
            profile.UserData.Description = "Przykładowy opis";
            profile.UserData.Name = "Nazwa";
            profile.UserData.Surname = "Nazwisko";
            
            return View(profile);
        }
    }
}