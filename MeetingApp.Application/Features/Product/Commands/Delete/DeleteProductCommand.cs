using ErrorOr;
using MediatR;

namespace MeetingApp.Application.Features.Product.Commands.Delete
{
    public class DeleteProductCommand : IRequest<ErrorOr<DeleteProductCommandResult>>
    {   
        public long Id { get; set; }
        
    }
}        