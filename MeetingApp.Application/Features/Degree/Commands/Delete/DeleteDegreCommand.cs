using ErrorOr;
using MediatR;

namespace MeetingApp.Application.Features.Degre.Commands.Delete
{
    public class DeleteDegreCommand : IRequest<ErrorOr<DeleteDegreCommandResult>>
    {   
        public long Id { get; set; }
        
    }
}        