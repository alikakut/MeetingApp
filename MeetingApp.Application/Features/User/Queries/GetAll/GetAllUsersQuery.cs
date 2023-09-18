using ErrorOr;
using MediatR;

namespace MeetingApp.Application.Features.Users.Queries.GetAll;

public class GetAllUsersQuery : IRequest<ErrorOr<List<GetAllUsersQueryResult>>>
{
    //public DataFilterModel DataFilter { get; set; }
}        