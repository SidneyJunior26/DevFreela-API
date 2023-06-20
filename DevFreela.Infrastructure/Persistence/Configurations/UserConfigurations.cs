using System;
using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasMany(u => u.Skills)
                .WithOne()
                .HasForeignKey(u => u.IdSkill)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.OwnedProjects)
                .WithOne()
                .HasForeignKey(u => u.IdClient)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(u => u.FreelanceProjects)
                .WithOne()
                .HasForeignKey(u => u.IdFreelancer)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

