using MeetingApp.Domain.Base;

namespace MeetingApp.Application.Features.Users.Queries.GetById
{
    public class GetByIdUsersQueryResult : BaseEntity
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public long PhomeNumber { get; set; }

        public string PasswordNo { get; set; }

    }
}