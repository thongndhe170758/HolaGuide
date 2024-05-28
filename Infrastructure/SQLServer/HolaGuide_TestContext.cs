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
        public virtual DbSet<Subscription> Subscriptions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserSubscription> UserSubscriptions { get; set; } = null!;

    }
}