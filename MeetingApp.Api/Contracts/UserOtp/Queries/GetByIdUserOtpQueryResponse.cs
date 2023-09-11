using MeetingApp.Api.Contracts.Base;

namespace MeetingApp.Api.Contracts.UserOtp.Queries
{
    public class GetByIdUserOtpQueryResponse : BaseResponseModel
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
