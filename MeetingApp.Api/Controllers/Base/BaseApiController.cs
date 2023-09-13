using ErrorOr;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MeetingApp.Api.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private readonly ILogger<BaseApiController> _logger;

        public BaseApiController(ILogger<BaseApiController> logger)
        {
            _logger = logger;
        }
        protected virtual async Task<IActionResult> ApiResponse<T>(object data)
        {
            var errorOrData = (IErrorOr)data;

            if (errorOrData.IsError)
            {
                _logger.LogWarning("Succes: {IsSuccess}, Date: {DateTime}, Data: {Data}", false, DateTime.Now, JsonConvert.SerializeObject(data));

                //return Problem(errorOrData.Errors.FirstOrDefault());
                return BadRequest();
            }
            else
            {
                _logger.LogWarning("Succes: {IsSuccess}, Date: {DateTime}, Data: {Data}", true, DateTime.Now, JsonConvert.SerializeObject(data));

                //ResolverHelper lookupHelper = new ResolverHelper(_cacheService);

                var resolverData = data.GetType().GetProperty("Value").GetValue(data);

                //lookupHelper.ResolveMapping(resolverData);

                // return Ok(new SecureResponse(CastErrorHandle(resolverData.Adapt<T>())));
                return Ok();
            }
        }
    }
}
