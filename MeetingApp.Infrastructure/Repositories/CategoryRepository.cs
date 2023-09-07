using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingApp.Application.Interfaces.Repositories;
using MeetingApp.Domain.Entities;

namespace MeetingApp.Infrastructure.Repositories.Base
{
    public class CategoryRepository : EfRepositoryBase<CategoryEntity> , ICategoryRepository
    {
    }
}
