using ErrorOr;
using Mapster;
using MediatR;
using MeetingApp.Application.Interfaces.Repositories;

namespace MeetingApp.Application.Features.Users.Queries.GetById
{
    public class GetByIdUsersQueryHandler : IRequestHandler<GetByIdUsersQuery, ErrorOr<GetByIdUsersQueryResult>>
    {
        private readonly IUserRepository _usersRepository;

        public GetByIdUsersQueryHandler(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<ErrorOr<GetByIdUsersQueryResult>> Handle(GetByIdUsersQuery request, CancellationToken cancellationToken)
        {
            var data = await _usersRepository.GetByIdAsync(request.Id);

            return data.Adapt<GetByIdUsersQueryResult>();
        }
    }
}  