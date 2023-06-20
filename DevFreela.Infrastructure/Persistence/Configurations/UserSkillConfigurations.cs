using System;
using System.Reflection.Emit;
using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class UserSkillConfigurations : IEntityTypeConfiguration<UserSkill>
    {
        public void Configure(EntityTypeBuilder<UserSkill> builder)
        {
            builder.HasKey(us => us.Id);

            builder.HasOne(us => us.Skill)
                .WithMany()
                .HasForeignKey(s => s.IdSkill)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

