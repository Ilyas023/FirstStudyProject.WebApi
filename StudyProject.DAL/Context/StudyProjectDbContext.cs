using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StudyProject.DAL.Models;

namespace StudyProject.DAL.Context;

public partial class StudyProjectDbContext : DbContext
{
    public StudyProjectDbContext()
    {
    }

    public StudyProjectDbContext(DbContextOptions<StudyProjectDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Human> Humans { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-Q6RQB80;Database=StudyProjectDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Human>(entity =>
        {
            entity.ToTable("Human");

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .IsFixedLength();
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.Description)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
