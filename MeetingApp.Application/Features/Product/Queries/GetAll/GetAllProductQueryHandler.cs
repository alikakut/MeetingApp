using ErrorOr;
using Mapster;
using MediatR;
using MeetingApp.Application.Interfaces.Repositories;

namespace MeetingApp.Application.Features.Product.Queries.GetAll
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, ErrorOr<List<GetAllProductQueryResult>>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ErrorOr<List<GetAllProductQueryResult>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var data = ToString();  await _productRepository.GetAll(request.DataFilter);

            return data.Adapt<List<GetAllProductQueryResult>>();
        }
    }
}        