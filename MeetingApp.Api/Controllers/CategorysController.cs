using MediatR;
using MeetingApp.Api.Contracts.Category.Queries;
using MeetingApp.Api.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Api.Controllers
{
    public class CategorysController : BaseApiController
    {
        private readonly IMediator _mediator;

    }
}
