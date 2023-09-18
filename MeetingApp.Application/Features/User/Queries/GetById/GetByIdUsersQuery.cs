using ErrorOr;
using MediatR;

namespace MeetingApp.Application.Features.Users.Queries.GetById;

public class GetByIdUsersQuery : IRequest<ErrorOr<GetByIdUsersQueryResult>>
{
    public long Id { get; set; }
}        