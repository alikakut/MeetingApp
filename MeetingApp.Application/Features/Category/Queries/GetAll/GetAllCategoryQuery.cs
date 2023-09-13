using ErrorOr;
using MediatR;

namespace MeetingApp.Application.Features.Category.Queries.GetAll;

public class GetAllCategoryQuery : IRequest<ErrorOr<List<GetAllCategoryQueryResult>>>
{
    //public DataFilterModel DataFilter { get; set; }
}        