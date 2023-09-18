using ErrorOr;
using MediatR;

namespace MeetingApp.Application.Features.Package.Commands.Update
{
    public class UpdatePackageCommand : IRequest<ErrorOr<UpdatePackageCommandResult>>
    {
        public long Id { get; set; }

        public long Price { get; set; }

    }
}