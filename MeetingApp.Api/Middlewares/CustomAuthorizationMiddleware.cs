using MeetingApp.Application.Extensions;
using MeetingApp.Application.Utilities.AppSettings;
using MeetingApp.Application.Utilities.Authorization.Attribute;
using MeetingApp.Application.Utilities.Authorization.Constant;
using MeetingApp.Application.Utilities.Authorization.Helper;
using MeetingApp.Application.Utilities.Authorization.Model;
using MeetingApp.Application.Utilities.Authorization.Session;
using MeetingApp.Application.Utilities.Exception;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Net;

namespace MeetingApp.Api.Middlewares
{
    public class CustomAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly IOptions<MeetingAppSettings> _appSettings;

        public CustomAuthorizationMiddleware(IOptions<MeetingAppSettings> appSettings, RequestDelegate next)
        {
            _appSettings = appSettings;
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            var endpoint = httpContext.GetEndpoint();

            if (endpoint is not null)
            {
                var hasPerm = endpoint.Metadata.OfType<HasPermissionAttribute>().ToList();
                var hasAuhtIgnore = endpoint.Metadata.OfType<AllowAnonymousAttribute>().ToList();

                if (hasPerm.IsNotNull() && hasPerm.Count != 0 && hasAuhtIgnore.Count == 0)
                {
                    if (httpContext.Request.Headers["Authorization"].IsNotNullOrEmpty() || !httpContext.Request.Headers["Authorization"].ToString().StartsWith("Bearer"))
                    {
                        throw new CustomException(TokenConstant.NOT_FOUND_TOKEN, HttpStatusCode.Unauthorized);
                    }

                    var token = httpContext.Request.Headers["Authorization"].ToString().Split(" ").Skip(1).First();

                    if (token.IsNullOrEmpty())
                        throw new CustomException(TokenConstant.NOT_FOUND_TOKEN, HttpStatusCode.Unauthorized);

                    try
                    {
                        var tokenHelper = new TokenHelper(_appSettings);
                        var loginResult = tokenHelper.ValidateToken(token);

                        if (loginResult.IsNull())
                            throw new CustomException(TokenConstant.INVALID_TOKEN, HttpStatusCode.Unauthorized);


                        new SessionManager(httpContext)
                        {
                            LoginResult = new PersonnelSessionModel
                            {
                                PersonnelId = loginResult.PersonnelId,
                                Username = loginResult.Username,
                                PersonnelType = loginResult.PersonnelType,
                                RefreshToken = loginResult.RefreshToken,
                                RefreshTokenEndDate = loginResult.RefreshTokenEndDate,
                                ValidTo = loginResult.ValidTo,
                                SaleChannelId = loginResult.SaleChannelId,
                                SaleChannelName = loginResult.SaleChannelName
                            },
                            PersonnelId = (int)loginResult.PersonnelId,
                            UserName = loginResult.Username
                        };
                    }
                    catch (CustomException customException)
                    {
                        throw customException;
                    }
                    catch (Exception)
                    {
                        throw new CustomException(TokenConstant.NOT_FOUND_TOKEN, HttpStatusCode.Unauthorized);
                    }
                }
            }

            await _next(httpContext);
        }
    }
    public static class CustomAuthorizationMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomAuthorizationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomAuthorizationMiddleware>();
        }
    }
}
