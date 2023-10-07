using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MeetingApp.Application.Extensions;
using MeetingApp.Application.Interfaces.Repositories.Base;
using MeetingApp.Application.Utilities.Authorization.Session;
using MeetingApp.Application.Utilities.Exception;
using MeetingApp.Application.Utilities.Sieve;
using MeetingApp.Domain.Base;
using MeetingApp.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;

namespace MeetingApp.Infrastructure.Repositories.Base
{
    public class EfRepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly MeetingAppDbContext _context;
        private readonly BaseApplicationSieveProcessor<DataFilterModel, FilterTerm, SortTerm> _sieveProcessor;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SessionManager _sessionManager;
        public EfRepositoryBase(MeetingAppDbContext context, BaseApplicationSieveProcessor<DataFilterModel, FilterTerm, SortTerm> sieveProcessor, IHttpContextAccessor httpContextAccessor, SessionManager sessionManager)
        {
            _dbSet = context.Set<TEntity>();
            _context = context;
            _sieveProcessor = sieveProcessor;
            _httpContextAccessor = httpContextAccessor;
            _sessionManager = sessionManager;
        }

        public TEntity Entity { get; set; }

        public async Task<TEntity> AddAsync(TEntity entity, bool IsSaveChanges = true)
        {
            //entity.CreatedDate = DateTime.ParseExact(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"), "dd.MM.yyyy HH:mm:ss", null);

            //if (_sessionManager != null && _sessionManager.PersonnelId != null)
            //{
            //    if (_sessionManager.PersonnelId != null)
            //        entity.CreatedBy = _sessionManager.PersonnelId.Value;
            //    else
            //        entity.CreatedBy = 1;

            //}
            //else if (entity.CreatedBy.IsNull() || entity.CreatedBy == 0)
            //{
            //    entity.CreatedBy = 1;
            //}

            await _dbSet.AddAsync(entity);

            if (IsSaveChanges)
            {
                this.Entity = entity;

                await SaveChangesAsync();
            }

            return entity;
        }

        public async Task Delete(long id)
        {
            var entity = await GetByIdAsync(id);

            entity.IsDeleted = true;

            await Update(entity);
        }

        public virtual async Task<List<TEntity>> GetAll(DataFilterModel dataFilterModel)
        {
            var data = _sieveProcessor.Apply<TEntity>(dataFilterModel, _dbSet.Where(x => !x.IsDeleted), applyPagination: false);

            if (data.IsNotNullOrEmpty())
                throw new CustomException("Kayıt bulunamadı", HttpStatusCode.BadRequest);

            if (!_httpContextAccessor.HttpContext!.Response.Headers.ContainsKey("X-Total-Count"))
                _httpContextAccessor.HttpContext.Response.Headers.Add("X-Total-Count", data.Count().ToString());

            return _sieveProcessor.Apply<TEntity>(dataFilterModel, data).ToList();
        }

        public virtual async Task<TEntity> GetByIdAsync(long id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
        }

        public async Task<TEntity> Update(TEntity entity, bool IsSaveChanges = true)
        {
            var oldValue = await this.GetByIdAsync(entity.Id.Value);

            _context.ChangeTracker.Entries().ToList().ForEach(x => x.State = EntityState.Detached);

            //if (_sessionManager != null && _sessionManager.UserName != null)
            //{
            //    if (_sessionManager != null)
            //    {
            //        if (_sessionManager.UserName != null)
            //            entity.UpdatedBy = _sessionManager.PersonnelId.Value;
            //        else
            //            entity.UpdatedBy = 1;
            //    }
            //}

            //entity.UpdatedDate = DateTime.Now;
            //entity.CreatedBy = oldValue.CreatedBy;

            _dbSet.Update(entity);

            if (IsSaveChanges)
            {
                this.Entity = entity;

                await SaveChangesAsync();
            }

            return oldValue;
        }

        public virtual async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbSet.Where(filter.AndAlso<TEntity>(x => !x.IsDeleted)).ToListAsync();
        }

        public virtual async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbSet.FirstOrDefaultAsync(filter.AndAlso<TEntity>(x => !x.IsDeleted));
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                var affectedRows = await _context.SaveChangesAsync();

                if (affectedRows <= 0)
                {
                    throw new CustomException("UnitOfWork saveChanges hatası.", HttpStatusCode.InternalServerError);
                }

                WriteHistory();

            }
            catch (Exception ex)
            {
                throw new CustomException($"UnitOfWork saveChanges hatası; {ex.Message}", HttpStatusCode.InternalServerError);
            }
        }

        public void WriteHistory()
        {

        }
    }
}
