using MeetingApp.Domain.Base;

namespace MeetingApp.Application.Features.UserOtp.Commands.Create
{
    public class CreateUserOtpCommandResult : BaseEntity
    {

        public string Email { get; set; }

        public string PasswordNo { get; set; }

    }
}