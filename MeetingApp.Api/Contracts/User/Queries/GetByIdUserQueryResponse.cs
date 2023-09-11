using MeetingApp.Api.Contracts.Base;

namespace MeetingApp.Api.Contracts.User.Queries
{
    public class GetByIdUserQueryResponse : BaseResponseModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int PhoneNumber { get; set; }

        public string Password { get; set; }
    }
}
