using MeetingApp.Api.Contracts.Base;

namespace MeetingApp.Api.Contracts.Package.Queries
{
    public class GetByIdPackageQueryResponse : BaseResponseModel
    {
        public string Detail { get; set; }
        public int Price { get; set; }
    }
}
