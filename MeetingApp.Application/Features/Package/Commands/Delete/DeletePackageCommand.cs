using ErrorOr;
using MediatR;

namespace MeetingApp.Application.Features.Package.Commands.Delete
{
    public class DeletePackageCommand : IRequest<ErrorOr<DeletePackageCommandResult>>
    {   
        public long Id { get; set; }
        
    }
}        