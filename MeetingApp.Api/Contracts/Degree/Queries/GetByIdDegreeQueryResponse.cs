using MeetingApp.Api.Contracts.Base;

namespace MeetingApp.Api.Contracts.Degree.Queries
{
    public class GetByIdDegreeQueryResponse : BaseResponseModel
    {
        public string Description { get; set; }
    }
}
