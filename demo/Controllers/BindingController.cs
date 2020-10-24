using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using demo.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo.Tools
{
    [Route("value-provider")]
    public class BindingController : Controller
    {
        // żądanie -> header (accept, auth-key), body (name, email), cookies, sesja (SESSION_ID), query (q, p, email), -> Fabryki Dostawców Wartości (jakie klucze niosą)

        // mechanizmy wiązania wartości (binding) -> email (ze wskazanego miejsca) -> transformacja wartości (string) na dany typ (prymytiwy, enumeracje, ...)
        
        [HttpGet]
        [Route("form-value-provider")]
        [ActionName("formvalue")]
        public IActionResult TestFormValueBinding() {
            return View();
        }

        [HttpPost]
        [Route("form-value-provider")]
        public IActionResult TestFormValueBinding([FromForm] string email) {
            ViewData["type"] = "FromForm";
            ViewData["result"] = email;
            return View("Result");
        }

        [HttpGet]
        [Route("route-value-provider/{id}")]        // route -> http:/asdfasd/kontroler/akcja/wartosc
        public IActionResult TestRouteValueBinding([FromRoute] string id) {
            ViewData["type"] = "FromRoute";
            ViewData["result"] = id;
            return View("Result");
        }

        [HttpGet]
        [Route("query-value-provider")] // query -> http://asdfasdf/kontroler/akcja?par1=wartosc1
        public IActionResult TestQueryValueBinding([FromQuery] string email) {
            ViewData["type"] = "FromQuery";
            ViewData["result"] = email;
            return View("Result");
        }

        [HttpGet]
        [Route("header-value-provider")]
        public IActionResult TestHeaderValueBinding([FromHeader] string email) {
            ViewData["type"] = "FromHeader";
            ViewData["result"] = email;
            return View("Result");
        }

        [HttpGet]
        [Route("di-provider")]
        public IActionResult TestDependencyInjection([FromServices] IHttpContextAccessor accessor) {
            ViewData["type"] = "FromServices";
            ViewData["result"] = accessor.HttpContext.GetEndpoint().DisplayName;
            return View("Result");
        }

        [HttpPost]
        [Route("body-value-provider")]
        public IActionResult TestBodyValueBinding([FromBody] string email) {
            ViewData["type"] = "FromBody";
            ViewData["result"] = email;
            return View("Result");
        }

        [HttpGet]
        [Route("binder-tester")]
        public IActionResult TestBindingModel(BinderTester tester) {
            ViewData["type"] = "Binder-tester";
            ViewData["result"] = tester;
            return View("Result");
        }

        [HttpGet]
        [Route("binder-tester-2")]
        public IActionResult TestBindingAction([Bind("Email, Id")] BinderTester tester) {   // FromQuery / FromForm / FromBody
            ViewData["type"] = "Binder-tester";
            ViewData["result"] = tester;
            return View("Result");
        }


        [HttpGet]
        [Route("long-action")]
        public async Task<string> LongAction(CancellationToken cancel) {
            await Task.Delay(10_000, cancel);

            return "Finished";
        }

        private List<int> createPrimeInts(int limit) {
            List<int> resp = new List<int>();
            for(int v = 2; resp.Count<limit; v++) {
                bool notPrime = false;
                for(int d=2; d<v-1; d++) {
                    if(v % d == 0) {
                        d = v;
                        notPrime = true;
                    }
                }
                if(!notPrime) {
                    resp.Add(v);
                }
            }
            return resp;
        }
    }
}