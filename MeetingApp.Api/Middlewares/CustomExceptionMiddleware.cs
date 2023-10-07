using MeetingApp.Application.Utilities.Exception;
using System.Net;
using System.Text.Json;

namespace MeetingApp.Api.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleException(httpContext, ex);
            }
        }
        private Task HandleException(HttpContext httpContext, Exception ex)
        {
            var response = httpContext.Response;
            response.ContentType = "application/json";
            string message = "";
            List<string> validationErrors = new List<string>();

            switch (ex)
            {
                case CustomException e:
                    switch (e.HttpStatusCode)
                    {
                        case HttpStatusCode.BadRequest:
                            response.StatusCode = (int)HttpStatusCode.BadRequest;
                            message = e.Message;
                            break;
                        case HttpStatusCode.InternalServerError:
                            response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            message = "Server kaynaklı hata.";
                            break;
                        case HttpStatusCode.Unauthorized:
                            response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            message = e.Message;
                            break;
                        case HttpStatusCode.Forbidden:
                            response.StatusCode = (int)HttpStatusCode.Forbidden;
                            message = e.Message;
                            break;
                        default:
                            response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
                            message = "IT birimi ile görüşünüz.";
                            break;
                    }
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
                    message = "IT birimi ile görüşünüz.";
                    break;
            }

            var result = new { IsSuccess = false, Message = message };

            return httpContext.Response.WriteAsJsonAsync(result, options: new JsonSerializerOptions { WriteIndented = true });
        }
    }
    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
