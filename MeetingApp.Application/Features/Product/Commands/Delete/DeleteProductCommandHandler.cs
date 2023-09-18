using ErrorOr;
using Mapster;
using MediatR;
using MeetingApp.Application.Interfaces.Repositories;
using MeetingApp.Domain.Entities;

namespace MeetingApp.Application.Features.Product.Commands.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ErrorOr<DeleteProductCommandResult>>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ErrorOr<DeleteProductCommandResult>> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            await _productRepository.Delete(command.Id);

            return new DeleteProductCommandResult();
        }
    }
}