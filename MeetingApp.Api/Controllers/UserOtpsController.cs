using MeetingApp.Api.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Api.Controllers
{
    public class UserOtpsController : BaseApiController
    {
        public UserOtpsController(ILogger<BaseApiController> logger) : base(logger)
        {
        }
    }
}
