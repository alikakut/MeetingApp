using ErrorOr;
using MediatR;

namespace MeetingApp.Application.Features.Users.Commands.Create
{
    public class CreateUsersCommand : IRequest<ErrorOr<CreateUsersCommandResult>>
    {


        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public long PhomeNumber { get; set; }

        public string PasswordNo { get; set; }

    }
}