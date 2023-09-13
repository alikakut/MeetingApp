using ErrorOr;
using MediatR;

namespace MeetingApp.Application.Features.Category.Queries.GetById;

public class GetByIdCategoryQuery : IRequest<ErrorOr<GetByIdCategoryQueryResult>>
{
    public long Id { get; set; }
}        