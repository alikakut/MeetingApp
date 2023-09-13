using MeetingApp.Api.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Api.Controllers
{
    public class PackagesController : BaseApiController
    {
        public PackagesController(ILogger<BaseApiController> logger) : base(logger)
        {
        }
    }
}
