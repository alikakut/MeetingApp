using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingApp.Application.Interfaces.Repositories;
using MeetingApp.Application.Utilities.Authorization.Session;
using MeetingApp.Application.Utilities.Sieve;
using MeetingApp.Domain.Entities;
using MeetingApp.Infrastructure.Persistence.Context;
using MeetingApp.Infrastructure.Repositories.Base;
using Microsoft.AspNetCore.Http;
using Sieve.Models;

namespace MeetingApp.Infrastructure.Repositories
{
    public class PackageRepository : EfRepositoryBase<PackageEntity>, IPackageRepository
    {
        public PackageRepository(MeetingAppDbContext context, BaseApplicationSieveProcessor<DataFilterModel, FilterTerm, SortTerm> sieveProcessor, IHttpContextAccessor httpContextAccessor, SessionManager sessionManager) : base(context, sieveProcessor, httpContextAccessor, sessionManager)
        {
        }
    }
}
