using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingApp.Application.Interfaces.Repositories;
using MeetingApp.Application.Utilities.Sieve;
using MeetingApp.Domain.Entities;

namespace MeetingApp.Infrastructure.Repositories.Base
{
    public class CategoryRepository : EfRepositoryBase<CategoryEntity>, ICategoryRepository
    {
        public Task GetAll(DataFilterModel dataFilter)
        {
            throw new NotImplementedException();
        }
    }
}
