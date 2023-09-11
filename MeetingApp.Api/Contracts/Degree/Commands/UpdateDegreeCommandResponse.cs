using MeetingApp.Api.Contracts.Base;

namespace MeetingApp.Api.Contracts.Degree.Commands
{
    public class UpdateDegreeCommandResponse : BaseResponseModel
    {
        public string Description { get; set; }
    }
}
