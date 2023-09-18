using ErrorOr;
using MediatR;

namespace MeetingApp.Application.Features.UserOtp.Commands.Update
{
    public class UpdateUserOtpCommand : IRequest<ErrorOr<UpdateUserOtpCommandResult>>
    {
        public long Id { get; set; }

        public string Email { get; set; }

        public string PasswordNo { get; set; }

    }
}