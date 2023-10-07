using ErrorOr;
using MediatR;
using MeetingApp.Application.Utilities.Sieve;

namespace MeetingApp.Application.Features.Product.Queries.GetAll;

public class GetAllProductQuery : IRequest<ErrorOr<List<GetAllProductQueryResult>>>
{
    public DataFilterModel DataFilter { get; set; }
}        