using MeetingApp.Domain.Base;

namespace MeetingApp.Application.Features.UserOtp.Queries.GetById
{
    public class GetByIdUserOtpQueryResult : BaseEntity
    {

        public string Email { get; set; }

        public string PasswordNo { get; set; }

    }
}