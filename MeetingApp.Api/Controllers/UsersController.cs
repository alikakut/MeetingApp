using Mapster;
using MediatR;
using MeetingApp.Api.Contracts.User.Commands;
using MeetingApp.Api.Contracts.User.Queries;
using MeetingApp.Api.Controllers.Base;
using MeetingApp.Application.Features.Users.Commands.Create;
using MeetingApp.Application.Features.Users.Commands.Delete;
using MeetingApp.Application.Features.Users.Commands.Update;
using MeetingApp.Application.Features.Users.Queries.GetAll;
using MeetingApp.Application.Features.Users.Queries.GetById;
using MeetingApp.Application.Interfaces.CacheService;
using MeetingApp.Application.Utilities.Sieve;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Api.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IMediator _mediator;

        public UsersController(ICacheService cacheService,ILogger<BaseApiController> logger, IMediator mediator) : base(cacheService, logger)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] DataFilterModel dataFilterModel)
        {
            return await ApiResponse<List<GetAllUserQueryResponse>>(await _mediator.Send(new GetAllUsersQuery { DataFilter = dataFilterModel }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            return await ApiResponse<GetByIdUserQueryResponse>(await _mediator.Send(new GetByIdUsersQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommandRequest request)
        {
            var command = request.Adapt<CreateUsersCommand>();
            return await ApiResponse<CreateUserCommandResponse>(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommandRequest request)
        {
            var command = request.Adapt<UpdateUsersCommand>();
            return await ApiResponse<UpdateUserCommandResponse>(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            return await ApiResponse<DeleteUserCommandResponse>(await _mediator.Send(new DeleteUsersCommand { Id = id }));
        }
    }
}
