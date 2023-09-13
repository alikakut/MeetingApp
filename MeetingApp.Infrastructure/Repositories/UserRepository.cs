using MeetingApp.Application.Interfaces.Repositories;
using MeetingApp.Domain.Entities;
using MeetingApp.Infrastructure.Repositories.Base;

namespace MeetingApp.Infrastructure.Repositories
{
    public class UserRepository : EfRepositoryBase<UserEntity> , IUserRepository
    {
    }
}
