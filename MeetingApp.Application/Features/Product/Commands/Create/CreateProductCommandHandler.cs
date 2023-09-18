using ErrorOr;
using Mapster;
using MediatR;
using MeetingApp.Application.Interfaces.Repositories;
using MeetingApp.Domain.Entities;

namespace MeetingApp.Application.Features.Product.Commands.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ErrorOr<CreateProductCommandResult>>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ErrorOr<CreateProductCommandResult>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var entity = command.Adapt<ProductEntity>();

            await _productRepository.AddAsync(entity);

            return new CreateProductCommandResult();
        }
    }
}        