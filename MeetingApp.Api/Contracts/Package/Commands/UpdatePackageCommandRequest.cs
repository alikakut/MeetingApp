using MeetingApp.Api.Contracts.Base;

namespace MeetingApp.Api.Contracts.Package.Commands
{
    public class UpdatePackageCommandRequest : BaseResquestModel
    {
        public long Id { get; set; }
        public string Detail { get; set; }
        public int Price { get; set; }
    }
}
