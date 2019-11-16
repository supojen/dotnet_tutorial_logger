using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Logging.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private ILogger _logger;

        // This is the statndard way of capturing the catagory
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    this._logger = logger;
        //}

        public HomeController(ILoggerFactory factory)
        {
            _logger = factory.CreateLogger("DemoCategory");
        }

        [Route("")]
        public IActionResult Index()
        {
            // Log Level
            // level 0: For information that's typically valuable only for debugging. Disabled by default.
            _logger.LogTrace("This is trace log.");
            // level 1: For information that may be useful in development and debugging.
            _logger.LogDebug("This is debug log.");
            // level 2: For tracking the general flow of the app.
            _logger.LogInformation("This is information log.");
            // level 3: For abnormal or unexpected events in the app flow. 
            _logger.LogWarning("This is warning log.");
            // level 4: For abnormal or unexpected events in the app flow. 
            _logger.LogError("This is error log.");
            // level 5: For failures that require immediate attention. 
            _logger.LogCritical("This is critical log.");
            return View();
        }
        [Route("second")]
        public IActionResult second()
        {
            // Why we use this way of formatting string
            // Because it is esay for structred logging
            _logger.LogError("The server went down temporarily at {time}", DateTime.Now);

            try
            {
                throw new Exception("You forgot to catch me!");

            } 
            catch(Exception ex)
            {
                _logger.LogCritical(ex,"There was a bad exception at {Time}",DateTime.UtcNow);
            }

            return Ok("Hello");
        }
    }

    public class LoggingId
    {
        public const int DemoCode = 1001;
    }
}