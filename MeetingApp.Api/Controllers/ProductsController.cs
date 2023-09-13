using MeetingApp.Api.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Api.Controllers
{
    public class ProductsController : BaseApiController
    {
        public ProductsController(ILogger<BaseApiController> logger) : base(logger)
        {
        }
    }
}
