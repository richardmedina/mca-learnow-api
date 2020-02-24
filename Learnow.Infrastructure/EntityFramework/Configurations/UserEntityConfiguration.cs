using Learnow.Domain.Entities;
using Learnow.Infrastructure.EntityFramework.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Learnow.Infrastructure.EntityFramework.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder
                .ToTable(EntityNames.USER, Schemas.BUSINESS);
        }
    }
}
