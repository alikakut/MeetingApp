using MeetingApp.Api.Contracts.Base;

namespace MeetingApp.Api.Contracts.Degree.Commands
{
    public class UpdateDegreeCommandRequest : BaseResquestModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
    }
}
