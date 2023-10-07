using ErrorOr;
using Mapster;
using MediatR;
using MeetingApp.Application.Interfaces.Repositories;

namespace MeetingApp.Application.Features.Users.Queries.GetAll
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ErrorOr<List<GetAllUsersQueryResult>>>
    {
        private readonly IUserRepository _usersRepository;

        public GetAllUsersQueryHandler(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<ErrorOr<List<GetAllUsersQueryResult>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var data = ToString(); await _usersRepository.GetAll(request.DataFilter);

            return data.Adapt<List<GetAllUsersQueryResult>>();
        }
    }
}        