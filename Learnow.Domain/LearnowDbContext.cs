using Learnow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Learnow.Domain
{
    public class LearnowDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public LearnowDbContext(DbContextOptions options) : base (options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
