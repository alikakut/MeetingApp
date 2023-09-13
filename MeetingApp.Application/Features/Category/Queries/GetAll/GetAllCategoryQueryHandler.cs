using ErrorOr;
using Mapster;
using MediatR;
using MeetingApp.Application.Interfaces.Repositories;

namespace MeetingApp.Application.Features.Category.Queries.GetAll
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, ErrorOr<List<GetAllCategoryQueryResult>>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ErrorOr<List<GetAllCategoryQueryResult>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var data = ToString(); //await _categoryRepository.GetAll(request.DataFilter);
            return data.Adapt<List<GetAllCategoryQueryResult>>();
        }
    }
}