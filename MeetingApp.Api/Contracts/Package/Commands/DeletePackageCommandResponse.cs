using MeetingApp.Api.Contracts.Base;

namespace MeetingApp.Api.Contracts.Package.Commands
{
    public class DeletePackageCommandResponse : BaseResponseModel
    {
        public string Detail { get; set; }
        public int Price { get; set; }
    }
}
