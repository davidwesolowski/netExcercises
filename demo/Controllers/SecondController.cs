using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace demo.Controllers {
    
    [Route("/Ciasteczka")]
    public class SecondController : Controller {

        private readonly IUrlHelperFactory _url;

        public HttpContext HttpContext { get; set; }

        public IUrlHelper Url { get; set; }
        

        public SecondController(IHttpContextAccessor contextAccessor, IUrlHelperFactory url) {
            _url = url;
            this.HttpContext = contextAccessor.HttpContext;
        }

        //[ControllerContext]
        //public ControllerContext ControllerContext { get; set;}

        [ActionContext]
        public ActionContext ActionContext { get; set; }

        //[ViewDataDictionary]
        //public ViewDataDictionary ViewBag { get; set; }


        [HttpGet]
        [ActionName("Reksio")]
        public IActionResult Index() {
            this.Url = this.Url ?? this._url.GetUrlHelper(this.ActionContext);
            
            // return "Akcja Index - nazywana Reksio - w kontrolerze Ciasteczka";
            return View();
            
        }

        // [ActionName("Index")]
        // public IActionResult Reksio() {
        //     return "Akcja Reksio - nazywana Index - w kontrolerze Ciasteczka";
        //     return View();
        // }
    }
}