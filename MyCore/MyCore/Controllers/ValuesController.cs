using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyCore.Controllers
{
    public class MyLogger<T>
    {
        private ILogger<T> _logger;

        public MyLogger(ILogger<T> logger)
        {
            _logger = logger;
        }

        public void WrieteLog(string msg)
        {
            _logger.LogCritical(msg);
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ILogger<ValuesController> _logger;
        private MyLogger<ValuesController> _myLogger;

        public ValuesController(
            ILogger<ValuesController> logger,
            MyLogger<ValuesController> myLogger)
        {
            _logger = logger;
            _myLogger = myLogger;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _logger.LogCritical("Hello world");
            _myLogger.WrieteLog("Wrapped Hello World");

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
