using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Balbet.DAL.Models;

namespace Balbet.DAL.DbContext
{
    public class BaseDbContext : System.Data.Entity.DbContext
    {
        public DbSet<User> Users { get; set; }

        protected BaseDbContext(string connectionString) : base(connectionString)
        {

        }
    }
}
