using ErrorOr;
using MediatR;

namespace MeetingApp.Application.Features.Users.Commands.Delete
{
    public class DeleteUsersCommand : IRequest<ErrorOr<DeleteUsersCommandResult>>
    {   
        public long Id { get; set; }
        
    }
}        