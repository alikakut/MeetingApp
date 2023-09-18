
using MeetingApp.Domain.Base;

namespace MeetingApp.Application.Features.Product.Queries.GetById
{
    public class GetByIdProductQueryResult : BaseEntity
    {

        public long? PackageId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public string Education { get; set; }

        public string Certificate { get; set; }

        public DateTime StartDate { get; set; }

    }
}