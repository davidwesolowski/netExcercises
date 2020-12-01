using System.Linq;
using System.Threading.Tasks;
using demo2.Persistance;
using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace demo2.Controllers
{
	[Authorize]
	public class SecureController : Controller
	{
		private PrimaryContext _context;
		private ICaptchaValidator _captchaValidator;

		public SecureController(PrimaryContext context, ICaptchaValidator captchaValidator)
		{
			this._context = context;
			this._captchaValidator = captchaValidator;
		}

		public IActionResult Index()
		{
			var query = from prod in _context.Products select prod;
			return View(query.ToList());
		}

		public IActionResult Details(int id)
		{
			throw new System.NotImplementedException();
		}

		[Authorize(Policy = "RequirePermissionForDelete")]
		public string Delete(int id)
		{
			return "1234"
				;
		}

		[Route("/captcha-form")]
		public IActionResult CaptchaFrom()
		{
			return View();
		}

		[HttpPost]
		[Route("/captcha-form")]
		public async Task<IActionResult> PostCaptchaForm(string name, string captcha)
		{
			if (!await _captchaValidator.IsCaptchaPassedAsync(captcha))
			{
				ModelState.AddModelError("captcha", "Captcha validation failed");
			}

			TempData["Message"] = "ok";
			return RedirectToAction("Index");
		}
	}
	
}