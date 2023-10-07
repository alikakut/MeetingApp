using ErrorOr;
using MediatR;
using MeetingApp.Application.Utilities.Sieve;

namespace MeetingApp.Application.Features.Package.Queries.GetAll;

public class GetAllPackageQuery : IRequest<ErrorOr<List<GetAllPackageQueryResult>>>
{
    public DataFilterModel DataFilter { get; set; }
}        