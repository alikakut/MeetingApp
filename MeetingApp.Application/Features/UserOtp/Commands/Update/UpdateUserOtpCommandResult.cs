using MeetingApp.Domain.Base;

namespace MeetingApp.Application.Features.UserOtp.Commands.Update
{
    public class UpdateUserOtpCommandResult : BaseEntity
    {

        public string Email { get; set; }

        public string PasswordNo { get; set; }

    }
}