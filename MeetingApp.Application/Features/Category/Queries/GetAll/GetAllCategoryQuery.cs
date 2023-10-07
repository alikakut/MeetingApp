using ErrorOr;
using MediatR;
using MeetingApp.Application.Utilities.Sieve;

namespace MeetingApp.Application.Features.Category.Queries.GetAll;

public class GetAllCategoryQuery : IRequest<ErrorOr<List<GetAllCategoryQueryResult>>>
{
    public DataFilterModel DataFilter { get; set; }
}        