
using demo.Tools;
using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers
{
    public class NestedController { }


    namespace Nested
    {
        
        [Tools.ControllerName("NestedFifthController")]       // adnotacja zmieniająca konwencję 
        public class SecondController {

            [ActionName("Reksio2")]
            public string Index() {
                return "Zgadnij jaki jest mój adres";       // url -> 
            }
        }
    }
}