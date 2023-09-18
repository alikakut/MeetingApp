using ErrorOr;
using MediatR;

namespace MeetingApp.Application.Features.Product.Commands.Create
{
    public class CreateProductCommand : IRequest<ErrorOr<CreateProductCommandResult>>
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