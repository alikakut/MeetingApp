using ErrorOr;
using MediatR;

namespace MeetingApp.Application.Features.UserOtp.Commands.Create
{
    public class CreateUserOtpCommand : IRequest<ErrorOr<CreateUserOtpCommandResult>>
    {


        public string Email { get; set; }

        public string PasswordNo { get; set; }

    }
}