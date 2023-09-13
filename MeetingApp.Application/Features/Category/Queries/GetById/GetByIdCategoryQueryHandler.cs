using ErrorOr;
using Mapster;
using MediatR;
using MeetingApp.Application.Interfaces.Repositories;

namespace MeetingApp.Application.Features.Category.Queries.GetById
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, ErrorOr<GetByIdCategoryQueryResult>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetByIdCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ErrorOr<GetByIdCategoryQueryResult>> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            var data = await _categoryRepository.GetByIdAsync(request.Id);

            return data.Adapt<GetByIdCategoryQueryResult>();
        }
    }
}  