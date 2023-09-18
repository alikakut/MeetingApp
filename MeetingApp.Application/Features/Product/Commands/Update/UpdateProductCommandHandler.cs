using ErrorOr;
using Mapster;
using MediatR;
using MeetingApp.Application.Interfaces.Repositories;
using MeetingApp.Domain.Entities;

namespace MeetingApp.Application.Features.Product.Commands.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ErrorOr<UpdateProductCommandResult>>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ErrorOr<UpdateProductCommandResult>> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var entity = command.Adapt<ProductEntity>();

            await _productRepository.Update(entity);

            return new UpdateProductCommandResult();
        }
    }
}