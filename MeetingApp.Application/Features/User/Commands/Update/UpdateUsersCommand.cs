using ErrorOr;
using MediatR;

namespace MeetingApp.Application.Features.Users.Commands.Update
{
    public class UpdateUsersCommand : IRequest<ErrorOr<UpdateUsersCommandResult>>
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public long PhomeNumber { get; set; }

        public string PasswordNo { get; set; }

    }
}