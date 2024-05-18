using System;
using System.Collections.Generic;
using Models.SQLServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.SQLServer
{
    public partial class HolaGuide_TestContext : DbContext
    {
        public HolaGuide_TestContext()
        {
        }

        public HolaGuide_TestContext(DbContextOptions<HolaGuide_TestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<SaveService> SaveServices { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<Subcription> Subcriptions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserSubcription> UserSubcriptions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Content).HasMaxLength(200);

                entity.Property(e => e.PostDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Feedback__UserID__44FF419A");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("Image");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.Value).HasMaxLength(200);

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__Image__ServiceID__45F365D3");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(100);
            });

            modelBuilder.Entity<SaveService>(entity =>
            {
                entity.ToTable("SaveService");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SaveDate).HasColumnType("datetime");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.SaveServices)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__SaveServi__Servi__4CA06362");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SaveServices)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__SaveServi__UserI__4D94879B");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.Price)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Service__Categor__46E78A0C");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__Service__Locatio__47DBAE45");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK__Service__OwnerID__4E88ABD4");
            });

            modelBuilder.Entity<Subcription>(entity =>
            {
                entity.ToTable("Subcription");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(20);
            });

            modelBuilder.Entity<UserSubcription>(entity =>
            {
                entity.ToTable("UserSubcription");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.SubcriptionId).HasColumnName("SubcriptionID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Subcription)
                    .WithMany(p => p.UserSubcriptions)
                    .HasForeignKey(d => d.SubcriptionId)
                    .HasConstraintName("FK__UserSubcr__Subcr__48CFD27E");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSubcriptions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserSubcr__UserI__49C3F6B7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
