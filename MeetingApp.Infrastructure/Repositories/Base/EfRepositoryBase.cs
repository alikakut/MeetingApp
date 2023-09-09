using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MeetingApp.Application.Interfaces.Repositories.Base;
using MeetingApp.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace MeetingApp.Infrastructure.Repositories.Base
{
    public class EfRepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {

        public DbContext _context { get; set; }
        public TEntity Entity { get; set; }
        protected DbSet<TEntity> _dbSet;

        public void Add(TEntity entity)
        {
            List<TEntity> data = new List<TEntity>();
            _dbSet.Add(entity);
            this.Entity = entity;
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
                throw new Exception("Silinecek öğe bulunamadı");

            entity.IsDeleted = true;

            this.Update(entity, deletion: true);
        }

        public TEntity GetById(long id, bool showDeleted = false)
        {
            TEntity _data = null;

            if (showDeleted == false)
                _data = _dbSet.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            else
                _data = _dbSet.FirstOrDefault(x => x.Id == id);

            return _data;
        }

        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.FirstOrDefault(filter);
        }

        public void Update(TEntity entity, bool deletion = false)
        {
            throw new NotImplementedException();
        }
    }
}
