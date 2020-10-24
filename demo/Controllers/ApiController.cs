using Microsoft.AspNetCore.Mvc;

namespace demo.Controllers.V1
{
    [ApiController]
    [Route("api")]
    [ApiVersion("1.0", Deprecated = true)]
    public class ApiController : ControllerBase {
        
        [HttpGet("test")]
        public string getVersion() {
            return "Ver 1.0";
        }
    }
}

// namespace demo.Controllers.V2
// {
//     [ApiController]
//     [Route("api")]
//     [ApiVersion("2.0")]
//     public class ApiController : ControllerBase {
        
//         [HttpGet("test")]
//         public string getVersion() {
//             return "Ver 2.0";
//         }
//     }
// }