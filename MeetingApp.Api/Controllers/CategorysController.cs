using Mapster;
using MediatR;
using MeetingApp.Api.Contracts.Category.Commands;
using MeetingApp.Api.Contracts.Category.Queries;
using MeetingApp.Api.Controllers.Base;
using MeetingApp.Application.Features.Category.Commands.Create;
using MeetingApp.Application.Features.Category.Commands.Delete;
using MeetingApp.Application.Features.Category.Commands.Update;
using MeetingApp.Application.Features.Category.Queries.GetAll;
using MeetingApp.Application.Features.Category.Queries.GetById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Api.Controllers
{
    public class CategorysController : BaseApiController
    {
        private readonly IMediator _mediator;
        public CategorysController(ILogger<BaseApiController> logger, IMediator mediator) : base(logger)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            return await ApiResponse<GetByIdCategoryQueryResponse>(await _mediator.Send(new GetByIdCategoryQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryCommandRequest request)
        {
            var command = request.Adapt<CreateCategoryCommand>();
            return await ApiResponse<CreateCategoryCommandResponse>(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommandRequest request)
        {
            var command = request.Adapt<UpdateCategoryCommand>();
            return await ApiResponse<UpdateCategoryCommandResponse>(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            return await ApiResponse<DeleteCategoryCommandResponse>(await _mediator.Send(new DeleteCategoryCommand { Id = id }));
        }
    }
}
