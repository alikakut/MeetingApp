using ErrorOr;
using Mapster;
using MediatR;
using MeetingApp.Application.Interfaces.Repositories;
using MeetingApp.Domain.Entities;

namespace MeetingApp.Application.Features.UserOtp.Commands.Delete
{
    public class DeleteUserOtpCommandHandler : IRequestHandler<DeleteUserOtpCommand, ErrorOr<DeleteUserOtpCommandResult>>
    {
        private readonly IUserOtpRepository _userOtpRepository;

        public DeleteUserOtpCommandHandler(IUserOtpRepository userOtpRepository)
        {
            _userOtpRepository = userOtpRepository;
        }

        public async Task<ErrorOr<DeleteUserOtpCommandResult>> Handle(DeleteUserOtpCommand command, CancellationToken cancellationToken)
        {
            await _userOtpRepository.Delete(command.Id);

            return new DeleteUserOtpCommandResult();
        }
    }
}