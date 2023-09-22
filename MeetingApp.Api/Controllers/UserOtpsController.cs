using Mapster;
using MediatR;
using MeetingApp.Api.Contracts.UserOtp.Commands;
using MeetingApp.Api.Contracts.UserOtp.Queries;
using MeetingApp.Api.Controllers.Base;
using MeetingApp.Application.Features.UserOtp.Commands.Create;
using MeetingApp.Application.Features.UserOtp.Commands.Delete;
using MeetingApp.Application.Features.UserOtp.Commands.Update;
using MeetingApp.Application.Features.UserOtp.Queries.GetAll;
using MeetingApp.Application.Features.UserOtp.Queries.GetById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Api.Controllers
{
    public class UserOtpsController : BaseApiController
    {
        private readonly IMediator _mediator;

        public UserOtpsController(ILogger<BaseApiController> logger, IMediator mediator) : base(logger)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            return await ApiResponse<GetByIdUserOtpQueryResponse>(await _mediator.Send(new GetByIdUserOtpQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserOtpCommandRequest request)
        {
            var command = request.Adapt<CreateUserOtpCommand>();
            return await ApiResponse<CreateUserOtpCommandResponse>(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserOtpCommandRequest request)
        {
            var command = request.Adapt<UpdateUserOtpCommand>();
            return await ApiResponse<UpdateUserOtpCommandResponse>(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            return await ApiResponse<DeleteUserOtpCommandResponse>(await _mediator.Send(new DeleteUserOtpCommand { Id = id }));
        }
    }
}
