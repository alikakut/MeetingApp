using ErrorOr;
using Mapster;
using MediatR;
using MeetingApp.Application.Interfaces.Repositories;
using MeetingApp.Domain.Entities;

namespace MeetingApp.Application.Features.Users.Commands.Update
{
    public class UpdateUsersCommandHandler : IRequestHandler<UpdateUsersCommand, ErrorOr<UpdateUsersCommandResult>>
    {
        private readonly IUserRepository _usersRepository;

        public UpdateUsersCommandHandler(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<ErrorOr<UpdateUsersCommandResult>> Handle(UpdateUsersCommand command, CancellationToken cancellationToken)
        {
            var entity = command.Adapt<UserEntity>();

            await _usersRepository.Update(entity);

            return new UpdateUsersCommandResult();
        }
    }
}