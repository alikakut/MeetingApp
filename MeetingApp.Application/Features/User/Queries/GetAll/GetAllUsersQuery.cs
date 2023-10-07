using ErrorOr;
using MediatR;
using MeetingApp.Application.Utilities.Sieve;

namespace MeetingApp.Application.Features.Users.Queries.GetAll;

public class GetAllUsersQuery : IRequest<ErrorOr<List<GetAllUsersQueryResult>>>
{
    public DataFilterModel DataFilter { get; set; }
}        