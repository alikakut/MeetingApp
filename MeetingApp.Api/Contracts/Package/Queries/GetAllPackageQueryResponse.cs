using MeetingApp.Api.Contracts.Base;

namespace MeetingApp.Api.Contracts.Package.Queries
{
    public class GetAllPackageQueryResponse : BaseResponseModel
    {
        public string Detail { get; set; }
        public int Price { get; set; }
    }
}
