using MeetingApp.Api.Contracts.Base;

namespace MeetingApp.Api.Contracts.UserOtp.Commands
{
    public class CreateUserOtpCommandResponse : BaseResponseModel
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
