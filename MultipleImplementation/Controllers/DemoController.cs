using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultipleImplementation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        public DemoController()
        {
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("Hello");
        }
    }
}
