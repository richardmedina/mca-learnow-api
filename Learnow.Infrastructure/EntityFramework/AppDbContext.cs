using Learnow.Domain.Entities;
using Learnow.Infrastructure.EntityFramework.Configurations;
using Learnow.Infrastructure.EntityFramework.Constants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Learnow.Infrastructure.EntityFramework
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public AppDbContext(DbContextOptions options) : base (options)
        {
            
        }
    }
}
