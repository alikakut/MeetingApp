using ErrorOr;
using Mapster;
using MediatR;
using MeetingApp.Application.Interfaces.Repositories;
using MeetingApp.Domain.Entities;

namespace MeetingApp.Application.Features.UserOtp.Commands.Update
{
    public class UpdateUserOtpCommandHandler : IRequestHandler<UpdateUserOtpCommand, ErrorOr<UpdateUserOtpCommandResult>>
    {
        private readonly IUserOtpRepository _userOtpRepository;

        public UpdateUserOtpCommandHandler(IUserOtpRepository userOtpRepository)
        {
            _userOtpRepository = userOtpRepository;
        }

        public async Task<ErrorOr<UpdateUserOtpCommandResult>> Handle(UpdateUserOtpCommand command, CancellationToken cancellationToken)
        {
            var entity = command.Adapt<UserOtpEntity>();

            await _userOtpRepository.Update(entity);

            return new UpdateUserOtpCommandResult();
        }
    }
}