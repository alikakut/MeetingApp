﻿using MeetingApp.Api.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Api.Controllers
{
    public class DegreesController : BaseApiController
    {
        public DegreesController(ILogger<BaseApiController> logger) : base(logger)
        {
        }
    }
}
