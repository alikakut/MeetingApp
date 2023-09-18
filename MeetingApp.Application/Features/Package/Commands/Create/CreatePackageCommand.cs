using ErrorOr;
using MediatR;

namespace MeetingApp.Application.Features.Package.Commands.Create
{
    public class CreatePackageCommand : IRequest<ErrorOr<CreatePackageCommandResult>>
    {
        public long Price { get; set; }

    }
}