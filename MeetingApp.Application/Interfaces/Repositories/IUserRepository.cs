using MeetingApp.Application.Interfaces.Repositories.Base;
using MeetingApp.Application.Utilities.Sieve;
using MeetingApp.Domain.Entities;

namespace MeetingApp.Application.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<UserEntity>
    {
        Task GetAll(DataFilterModel dataFilter);
    }
}
