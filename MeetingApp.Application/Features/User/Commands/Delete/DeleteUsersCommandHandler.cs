using ErrorOr;
using Mapster;
using MediatR;
using MeetingApp.Application.Interfaces.Repositories;
using MeetingApp.Domain.Entities;

namespace MeetingApp.Application.Features.Users.Commands.Delete
{
    public class DeleteUsersCommandHandler : IRequestHandler<DeleteUsersCommand, ErrorOr<DeleteUsersCommandResult>>
    {
        private readonly IUserRepository _usersRepository;

        public DeleteUsersCommandHandler(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<ErrorOr<DeleteUsersCommandResult>> Handle(DeleteUsersCommand command, CancellationToken cancellationToken)
        {
            await _usersRepository.Delete(command.Id);

            return new DeleteUsersCommandResult();
        }
    }
}