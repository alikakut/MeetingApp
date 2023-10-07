using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingApp.Application.Interfaces.Repositories;
using MeetingApp.Application.Utilities.Sieve;
using MeetingApp.Domain.Entities;
using MeetingApp.Infrastructure.Repositories.Base;

namespace MeetingApp.Infrastructure.Repositories
{
    public class ProductRepository : EfRepositoryBase<ProductEntity>, IProductRepository
    {
        public Task GetAll(DataFilterModel dataFilter)
        {
            throw new NotImplementedException();
        }
    }
}
