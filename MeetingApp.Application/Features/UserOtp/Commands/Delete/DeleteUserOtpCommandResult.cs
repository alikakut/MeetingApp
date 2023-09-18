using MeetingApp.Domain.Base;

namespace MeetingApp.Application.Features.UserOtp.Commands.Delete
{
    public class DeleteUserOtpCommandResult : BaseEntity
    {

        public string Email { get; set; }

        public string PasswordNo { get; set; }

    }
}