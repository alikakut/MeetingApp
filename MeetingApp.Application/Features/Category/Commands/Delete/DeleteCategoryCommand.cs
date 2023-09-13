using ErrorOr;
using MediatR;

namespace MeetingApp.Application.Features.Category.Commands.Delete
{
    public class DeleteCategoryCommand : IRequest<ErrorOr<DeleteCategoryCommandResult>>
    {   
        public long Id { get; set; }
        
    }
}        