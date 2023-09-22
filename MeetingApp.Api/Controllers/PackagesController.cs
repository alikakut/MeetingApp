using Mapster;
using MediatR;
using MeetingApp.Api.Contracts.Package.Commands;
using MeetingApp.Api.Contracts.Package.Queries;
using MeetingApp.Api.Controllers.Base;
using MeetingApp.Application.Features.Package.Commands.Create;
using MeetingApp.Application.Features.Package.Commands.Delete;
using MeetingApp.Application.Features.Package.Commands.Update;
using MeetingApp.Application.Features.Package.Queries.GetAll;
using MeetingApp.Application.Features.Package.Queries.GetById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Api.Controllers
{
    public class PackagesController : BaseApiController
    {
        private readonly IMediator _mediator;

        public PackagesController(ILogger<BaseApiController> logger, IMediator mediator) : base(logger)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            return await ApiResponse<GetByIdPackageQueryResponse>(await _mediator.Send(new GetByIdPackageQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePackageCommandRequest request)
        {
            var command = request.Adapt<CreatePackageCommand>();
            return await ApiResponse<CreatePackageCommandResponse>(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePackageCommandRequest request)
        {
            var command = request.Adapt<UpdatePackageCommand>();
            return await ApiResponse<UpdatePackageCommandResponse>(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            return await ApiResponse<DeletePackageCommandResponse>(await _mediator.Send(new DeletePackageCommand { Id = id }));
        }
    }
}
