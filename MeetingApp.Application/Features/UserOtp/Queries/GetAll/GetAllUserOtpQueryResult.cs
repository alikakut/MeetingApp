using MeetingApp.Domain.Base;

namespace MeetingApp.Application.Features.UserOtp.Queries.GetAll
{
    public class GetAllUserOtpQueryResult : BaseEntity
    {

        public string Email { get; set; }

        public string PasswordNo { get; set; }

    }
}