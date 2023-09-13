using MeetingApp.Api.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Api.Controllers
{
    public class UsersController : BaseApiController
    {
        public UsersController(ILogger<BaseApiController> logger) : base(logger)
        {
        }
    }
}
