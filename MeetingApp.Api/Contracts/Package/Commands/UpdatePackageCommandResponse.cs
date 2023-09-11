using MeetingApp.Api.Contracts.Base;

namespace MeetingApp.Api.Contracts.Package.Commands
{
    public class UpdatePackageCommandResponse : BaseResponseModel
    {
        public string Detail { get; set; }
        public int Price { get; set; }
    }
}
