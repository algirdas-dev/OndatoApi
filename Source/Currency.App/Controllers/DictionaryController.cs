using Ondato.Domain.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Threading.Tasks;
using Ondato.Api.Models.DictionaryController;
using System;

namespace Ondato.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DictionaryController : BaseController
    {
        private readonly IDictionaryService _service;
        public DictionaryController(ILogger<DictionaryController> logger, IDictionaryService service) :base(logger)
        {
            _service = service;
        }


        [HttpPost("Create")]
        [SwaggerOperation("Create")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateReq req)
        {
            if (string.IsNullOrWhiteSpace(req.Key))
                return NotFound("Method Dictionary/Create params");

            Logger.LogInformation($"Create dictionary key: {req.Key}");
            
            await _service.Create(req.Key).ConfigureAwait(false);

            return Ok();
        }

        [HttpPut("Append")]
        [SwaggerOperation("Append")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Append([FromBody] AppendReq req)
        {
            if (string.IsNullOrWhiteSpace(req.Key) || req.Value == null)
                NotFound("Method Dictionary/Append params");

            Logger.LogInformation($"Append dictionary key: {req.Key}, value: ${req.Value}");
            

            await _service.Append(req.Key, req.Value).ConfigureAwait(false);

            return Ok();
        }

        [HttpDelete("Delete")]
        [SwaggerOperation("Delete")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Delete([FromBody] DeleteReq req)
        {
            if (string.IsNullOrWhiteSpace(req.Key))
                this.NotFound("Method Dictionary/Delete params");

            Logger.LogInformation($"Delete dictionary key: {req.Key}");

            await _service.Delete(req.Key).ConfigureAwait(false);

            return Ok();
        }

        [HttpGet("Get")]
        [SwaggerOperation("Get")]
        [ProducesResponseType((int)HttpStatusCode.OK,Type = typeof(IEquatable<object>))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] DeleteReq req)
        {
            if (string.IsNullOrWhiteSpace(req.Key))
                this.NotFound("Method Dictionary/Get params");

            Logger.LogInformation($"Delete dictionary key: {req.Key}");
            
            var result = await _service.Get(req.Key).ConfigureAwait(false);

            if (result == null)
                return NotFound($"Dictionary key not exist: {req.Key}");

            return Ok(result);
        }
    }
}
