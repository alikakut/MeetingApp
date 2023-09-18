using ErrorOr;
using MediatR;

namespace MeetingApp.Application.Features.Product.Commands.Update
{
    public class UpdateProductCommand : IRequest<ErrorOr<UpdateProductCommandResult>>
    {
        public long Id { get; set; }

        public long? PackageId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public string Education { get; set; }

        public string Certificate { get; set; }

        public DateTime StartDate { get; set; }

    }
}