using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("users");
            builder.HasKey(u => u.id);
            builder.HasIndex(u => u.email).IsUnique();
            builder.Property(u=> u.name).IsRequired().HasMaxLength(60);
            builder.Property(u=> u.email).HasMaxLength(100);
        }
    }
}
