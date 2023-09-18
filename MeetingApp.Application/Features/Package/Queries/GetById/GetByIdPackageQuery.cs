using ErrorOr;
using MediatR;

namespace MeetingApp.Application.Features.Package.Queries.GetById;

public class GetByIdPackageQuery : IRequest<ErrorOr<GetByIdPackageQueryResult>>
{
    public long Id { get; set; }
}        