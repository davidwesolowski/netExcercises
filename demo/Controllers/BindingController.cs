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


        [Route("route-value-provider/{id}")]        // route -> http:/asdfasd/kontroler/akcja/wartosc
        public IActionResult TestRouteValueBinding([FromRoute] string id) {
            ViewData["type"] = "FromRoute";
            ViewData["result"] = id;
            return View("Result");
        }

        [Route("query-value-provider")] // query -> http://asdfasdf/kontroler/akcja?par1=wartosc1
        public IActionResult TestQueryValueBinding([FromQuery] string email) {
            ViewData["type"] = "FromQuery";
            ViewData["result"] = email;
            return View("Result");
        }

        [Route("header-value-provider")]
        public IActionResult TestHeaderValueBinding([FromHeader] string email) {
            ViewData["type"] = "FromHeader";
            ViewData["result"] = email;
            return View("Result");
        }

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

        [Route("binder-tester")]
        public IActionResult TestBindingModel(BinderTester tester) {
            ViewData["type"] = "Binder-tester";
            ViewData["result"] = tester;
            return View("Result");
        }

        [Route("binder-tester-2")]
        public IActionResult TestBindingAction([Bind("Email, Id")] BinderTester tester) {   // FromQuery / FromForm / FromBody
            ViewData["type"] = "Binder-tester";
            ViewData["result"] = tester;
            return View("Result");
        }

        [Route("long-action")]
        public async Task<List<int>> LongAction(CancellationToken cancel) {
            Task<List<int>> task = Task.Run(() => createPrimeInts(10000, cancel));
            List<int> result = await task;
            return result;
        }

        private List<int> createPrimeInts(int limit, CancellationToken cancel) {
            List<int> resp = new List<int>();
            try {
                for(int v = 2; resp.Count<limit; v++) {
                    bool notPrime = false;
                    for(int d=2; d<v-1; d++) {
                        if(v % d == 0) {
                            d = v;
                            notPrime = true;
                        }
                        if (cancel.IsCancellationRequested)
                        {
                            cancel.ThrowIfCancellationRequested();
                        }
                    }
                    if(!notPrime) {
                        resp.Add(v);
                    }
                }
            }
            catch (System.OperationCanceledException) {
                System.Console.WriteLine("@@@@@@@@  Cancelled createPrimeInts task @@@@@@@@@");
            }
            return resp;
        }
    }
}