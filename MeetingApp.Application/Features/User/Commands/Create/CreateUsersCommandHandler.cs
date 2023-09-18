using ErrorOr;
using Mapster;
using MediatR;
using MeetingApp.Application.Interfaces.Repositories;
using MeetingApp.Domain.Entities;

namespace MeetingApp.Application.Features.Users.Commands.Create
{
    public class CreateUsersCommandHandler : IRequestHandler<CreateUsersCommand, ErrorOr<CreateUsersCommandResult>>
    {
        private readonly IUserRepository _usersRepository;

        public CreateUsersCommandHandler(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<ErrorOr<CreateUsersCommandResult>> Handle(CreateUsersCommand command, CancellationToken cancellationToken)
        {
            var entity = command.Adapt<UserEntity>();

            await _usersRepository.AddAsync(entity);

            return new CreateUsersCommandResult();
        }
    }
}        