using MeetingApp.Domain.Base;

namespace MeetingApp.Application.Features.Users.Commands.Delete
{
    public class DeleteUsersCommandResult : BaseEntity
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public long PhomeNumber { get; set; }

        public string PasswordNo { get; set; }

    }
}