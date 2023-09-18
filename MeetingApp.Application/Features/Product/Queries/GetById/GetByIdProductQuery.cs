using ErrorOr;
using MediatR;

namespace MeetingApp.Application.Features.Product.Queries.GetById;

public class GetByIdProductQuery : IRequest<ErrorOr<GetByIdProductQueryResult>>
{
    public long Id { get; set; }
}        