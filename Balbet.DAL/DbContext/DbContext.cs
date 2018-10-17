using Balbet.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balbet.DAL.DbContext
{
    public class DbContext : BaseDbContext
    {
        public DbContext() : base("Balbet")
        {
            Database.SetInitializer<DbContext>(new DropCreateDatabaseIfModelChanges<DbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Users").HasKey(p => p.Login);
            modelBuilder.Entity<User>().Property(p => p.Password).IsRequired();
            modelBuilder.Entity<User>().Property(p => p.Sex);
            modelBuilder.Entity<User>().Property(p => p.Passport);
            modelBuilder.Entity<User>().Property(p => p.LastName);
            modelBuilder.Entity<User>().Property(p => p.FirstName);
            modelBuilder.Entity<User>().Property(p => p.Age);
        }

    }
}
