using ErrorOr;
using Mapster;
using MediatR;
using MeetingApp.Application.Interfaces.Repositories;

namespace MeetingApp.Application.Features.Product.Queries.GetById
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, ErrorOr<GetByIdProductQueryResult>>
    {
        private readonly IProductRepository _productRepository;

        public GetByIdProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ErrorOr<GetByIdProductQueryResult>> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            var data = await _productRepository.GetByIdAsync(request.Id);

            return data.Adapt<GetByIdProductQueryResult>();
        }
    }
}  