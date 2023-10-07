using Mapster;
using MediatR;
using MeetingApp.Api.Contracts.Degree.Commands;
using MeetingApp.Api.Contracts.Degree.Queries;
using MeetingApp.Api.Controllers.Base;
using MeetingApp.Application.Features.Degre.Commands.Create;
using MeetingApp.Application.Features.Degre.Commands.Delete;
using MeetingApp.Application.Features.Degre.Commands.Update;
using MeetingApp.Application.Features.Degre.Queries.GetAll;
using MeetingApp.Application.Features.Degre.Queries.GetById;
using MeetingApp.Application.Interfaces.CacheService;
using MeetingApp.Application.Utilities.Sieve;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Api.Controllers
{
    public class DegreesController : BaseApiController
    {
        private readonly IMediator _mediator;

        public DegreesController(ICacheService cacheService, ILogger<BaseApiController> logger, IMediator mediator) : base(cacheService,logger)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] DataFilterModel dataFilterModel)
        {
            return await ApiResponse<List<GetAllDegreeQueryResponse>>(await _mediator.Send(new GetAllDegreQuery { DataFilter = dataFilterModel }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            return await ApiResponse<GetByIdDegreeQueryResponse>(await _mediator.Send(new GetByIdDegreQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDegreeCommandRequest request)
        {
            var command = request.Adapt<CreateDegreCommand>();
            return await ApiResponse<CreateDegreeCommandResponse>(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDegreeCommandRequest request)
        {
            var command = request.Adapt<UpdateDegreCommand>();
            return await ApiResponse<UpdateDegreeCommandResponse>(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            return await ApiResponse<DeleteDegreeCommandResponse>(await _mediator.Send(new DeleteDegreCommand { Id = id }));
        }
    }
}
