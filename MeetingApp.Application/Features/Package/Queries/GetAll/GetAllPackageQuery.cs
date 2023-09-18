using ErrorOr;
using MediatR;

namespace MeetingApp.Application.Features.Package.Queries.GetAll;

public class GetAllPackageQuery : IRequest<ErrorOr<List<GetAllPackageQueryResult>>>
{
   // public DataFilterModel DataFilter { get; set; }
}        