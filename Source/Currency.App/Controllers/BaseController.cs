using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Ondato.Api.Controllers
{
    
    public abstract class BaseController : ControllerBase
    {
        protected readonly ILogger<DictionaryController> Logger;
        public BaseController(ILogger<DictionaryController> logger) {
            Logger = logger;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public NotFoundResult NotFound(string logMessage)
        {
            Logger.LogWarning($"Not Found: {logMessage}, Date: {DateTimeOffset.Now}");
            return this.NotFound();
        }

    }
}
