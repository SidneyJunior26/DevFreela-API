﻿using System;
using System.Reflection.Emit;
using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class ProjectCommentConfigurations : IEntityTypeConfiguration<ProjectComment>
    {
        public void Configure(EntityTypeBuilder<ProjectComment> builder)
        {
            builder.HasKey(pc => pc.Id);

            builder.HasOne(pc => pc.Project)
                .WithMany()
                .HasForeignKey(pc => pc.IdProject)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pc => pc.User)
                .WithMany(pc => pc.Comments)
                .HasForeignKey(pc => pc.IdUser)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

