using Coursework.Entity.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.DAL
{
    public class MyDbContext : IdentityDbContext<User>
    {
        static MyDbContext()
        {
            Database.SetInitializer(new MyDbInitializer());
        }

        public MyDbContext()
            : base("CourseworkConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Flower> Flowers { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public static MyDbContext Create()
        {
            return new MyDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Picture>()
                .HasKey(p => p.FlowerId)
                .HasRequired(p => p.Flower)
                .WithOptional(a => a.Picture);
            modelBuilder.Entity<Flower>()
                .HasOptional(f => f.Picture)
                .WithRequired(p => p.Flower)
                .WillCascadeOnDelete();

        }
    }
}
