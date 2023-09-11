using MeetingApp.Api.Contracts.Base;

namespace MeetingApp.Api.Contracts.UserOtp.Commands
{
    public class UpdateUserOtpCommandRequest : BaseResquestModel
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
