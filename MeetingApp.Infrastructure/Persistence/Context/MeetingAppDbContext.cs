using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeetingApp.Infrastructure.Persistence.Context
{
    public class MeetingAppDbContext : DbContext
    {
        public MeetingAppDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<ProductEntity> ProductEntities { get; set; }
        public DbSet<CategoryEntity> CategoryEntities { get; set; }
        public DbSet<PackageEntity> PackageEnities { get; set; }
        public DbSet<DegreeEntity> DegreeEntities{ get; set; }
        public DbSet<UserEntity> UserEntities { get; set; }
        public DbSet<UserOtpEntity> UserOtpEntities { get; set;}


    }
}
