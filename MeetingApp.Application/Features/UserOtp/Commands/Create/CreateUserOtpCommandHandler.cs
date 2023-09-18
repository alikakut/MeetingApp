using ErrorOr;
using Mapster;
using MediatR;
using MeetingApp.Application.Interfaces.Repositories;
using MeetingApp.Domain.Entities;

namespace MeetingApp.Application.Features.UserOtp.Commands.Create
{
    public class CreateUserOtpCommandHandler : IRequestHandler<CreateUserOtpCommand, ErrorOr<CreateUserOtpCommandResult>>
    {
        private readonly IUserOtpRepository _userOtpRepository;

        public CreateUserOtpCommandHandler(IUserOtpRepository userOtpRepository)
        {
            _userOtpRepository = userOtpRepository;
        }

        public async Task<ErrorOr<CreateUserOtpCommandResult>> Handle(CreateUserOtpCommand command, CancellationToken cancellationToken)
        {
            var entity = command.Adapt<UserOtpEntity>();

            await _userOtpRepository.AddAsync(entity);

            return new CreateUserOtpCommandResult();
        }
    }
}        