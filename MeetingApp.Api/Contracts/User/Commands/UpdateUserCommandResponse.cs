using MeetingApp.Api.Contracts.Base;

namespace MeetingApp.Api.Contracts.User.Commands
{
    public class UpdateUserCommandResponse : BaseResponseModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int PhoneNumber { get; set; }

        public string Password { get; set; }
    }
}
