using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MeetingApp.Domain.Base;

namespace MeetingApp.Application.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        TEntity Entity { get; set; }
        TEntity GetById(long id, bool showDeleted = false);
        //IQueryable<TEntity> GetAll(DataFilterModel dataFilterModel);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity, bool deletion = false);
        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter);

        //TEntity Entity { get; set; }
        //Task<TEntity> GetByIdAsync(long id);
        ////Task<List<TEntity>> GetAll(DataFilterModel dataFilterModel);
        //Task<TEntity> AddAsync(TEntity entity, bool IsSaveChanges = true);
        //Task Delete(long id);
        //Task<TEntity> Update(TEntity entity, bool IsSaveChanges = true);
        //Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter);
        //Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter);
        //Task SaveChangesAsync();
    }
}
