using ErrorOr;
using MediatR;
using MeetingApp.Application.Utilities.Sieve;

namespace MeetingApp.Application.Features.Degre.Queries.GetAll;

public class GetAllDegreQuery : IRequest<ErrorOr<List<GetAllDegreQueryResult>>>
{
    public DataFilterModel DataFilter { get; set; }
}        