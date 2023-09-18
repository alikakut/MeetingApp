using MeetingApp.Api.Contracts.Base;
using MeetingApp.Domain.Entities;

namespace MeetingApp.Api.Contracts.Product.Queries
{
    public class GetByIdProductQueryResponse : BaseResponseModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public long? PackageDate { get; set; }

        public string? Education { get; set; }

        public string? Certificate { get; set; }

        public PackageEntity Package { get; set; }
    }
}
