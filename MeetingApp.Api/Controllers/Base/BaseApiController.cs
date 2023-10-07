using ErrorOr;
using Mapster;
using MeetingApp.Application.Interfaces.CacheService;
using MeetingApp.Application.Utilities.ResponseRequestEncrypt;
using MeetingApp.Infrastructure.LookupHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MeetingApp.Api.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private readonly ICacheService _cacheService;
        private readonly ILogger<BaseApiController> _logger;

        public BaseApiController(ICacheService cacheService, ILogger<BaseApiController> logger)
        {
            _cacheService = cacheService;
            _logger = logger;
        }

        protected virtual async Task<IActionResult> ApiResponse<T>(object data)
        {
            var errorOrData = (IErrorOr)data;

            if (errorOrData.IsError)
            {
                _logger.LogWarning("Succes: {IsSuccess}, Date: {DateTime}, Data: {Data}", false, DateTime.Now, JsonConvert.SerializeObject(data));

                return Problem(errorOrData.Errors.FirstOrDefault());
            }
            else
            {
                _logger.LogWarning("Succes: {IsSuccess}, Date: {DateTime}, Data: {Data}", true, DateTime.Now, JsonConvert.SerializeObject(data));

                ResolverHelper lookupHelper = new ResolverHelper(_cacheService);

                var resolverData = data.GetType().GetProperty("Value").GetValue(data);

                lookupHelper.ResolveMapping(resolverData);

                return Ok(new SecureResponse(CastErrorHandle(resolverData.Adapt<T>())));
            }
        }

        private IActionResult Problem(Error error)
        {
            var statusCode = error.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            HttpContext.Items["errors"] = error;

            return Problem(statusCode: statusCode, title: error.Description);
        }
        private ErrorOr<object> CastErrorHandle(object value)
        {
            return value;
        }

    }
}
