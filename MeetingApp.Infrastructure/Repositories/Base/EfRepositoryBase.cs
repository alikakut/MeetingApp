using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MeetingApp.Application.Interfaces.Repositories.Base;
using MeetingApp.Domain.Base;

namespace MeetingApp.Infrastructure.Repositories.Base
{
    public class EfRepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        public TEntity Entity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task<TEntity> AddAsync(TEntity entity, bool IsSaveChanges = true)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Update(TEntity entity, bool IsSaveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
