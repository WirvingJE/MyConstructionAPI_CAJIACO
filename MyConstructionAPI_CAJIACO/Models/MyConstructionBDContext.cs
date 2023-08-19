using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyConstructionAPI_CAJIACO.Models
{
    public partial class MyConstructionBDContext : DbContext
    {
        public MyConstructionBDContext()
        {
        }

        public MyConstructionBDContext(DbContextOptions<MyConstructionBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Construction> Constructions { get; set; } = null!;
        public virtual DbSet<ConstructionCategory> ConstructionCategories { get; set; } = null!;
        public virtual DbSet<ConstructionStep> ConstructionSteps { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("SERVER=.; DATABASE=MyConstructionBD; INTEGRATED SECURITY=FALSE; USER ID=MyConstructionAPIUser; PASSWORD=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Construction>(entity =>
            {
                entity.HasKey(e => e.ProtocolId)
                    .HasName("PK__Construc__C11318377B263F27");

                entity.ToTable("Construction");

                entity.Property(e => e.ProtocolId).HasColumnName("ProtocolID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(1500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.ConstructionCategoryNavigation)
                    .WithMany(p => p.Constructions)
                    .HasForeignKey(d => d.ConstructionCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKConstructi986538");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Constructions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKConstructi355110");

                entity.HasMany(d => d.ConstructionStepConstructionSteps)
                    .WithMany(p => p.ConstructionProtocols)
                    .UsingEntity<Dictionary<string, object>>(
                        "ConstructionDetail",
                        l => l.HasOne<ConstructionStep>().WithMany().HasForeignKey("ConstructionStepConstructionStepsId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FKConstructi875491"),
                        r => r.HasOne<Construction>().WithMany().HasForeignKey("ConstructionProtocolId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FKConstructi620011"),
                        j =>
                        {
                            j.HasKey("ConstructionProtocolId", "ConstructionStepConstructionStepsId").HasName("PK__Construc__B392907C6BD78020");

                            j.ToTable("ConstructionDetail");

                            j.IndexerProperty<int>("ConstructionProtocolId").HasColumnName("ConstructionProtocolID");

                            j.IndexerProperty<int>("ConstructionStepConstructionStepsId").HasColumnName("ConstructionStepConstructionStepsID");
                        });
            });

            modelBuilder.Entity<ConstructionCategory>(entity =>
            {
                entity.HasKey(e => e.ConstructionCategory1)
                    .HasName("PK__Construc__1B6FA1296E972856");

                entity.ToTable("ConstructionCategory");

                entity.Property(e => e.ConstructionCategory1).HasColumnName("ConstructionCategory");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ConstructionCategories)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKConstructi476144");
            });

            modelBuilder.Entity<ConstructionStep>(entity =>
            {
                entity.HasKey(e => e.ConstructionStepsId)
                    .HasName("PK__Construc__A417296D40C58792");

                entity.ToTable("ConstructionStep");

                entity.Property(e => e.ConstructionStepsId).HasColumnName("ConstructionStepsID");

                entity.Property(e => e.Description)
                    .HasMaxLength(1500)
                    .IsUnicode(false);

                entity.Property(e => e.Step)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ConstructionSteps)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKConstructi444599");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Address)
                    .HasMaxLength(1500)
                    .IsUnicode(false);

                entity.Property(e => e.BackUpEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IsBlocked)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKUser854768");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole");

                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
