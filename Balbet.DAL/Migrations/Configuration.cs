namespace Balbet.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Balbet.DAL.DbContext.DbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Balbet.DAL.DbContext.DbContext";
        }

        protected override void Seed(Balbet.DAL.DbContext.DbContext context)
        {
            for (int userNumber = 0; userNumber < 100; userNumber++)
            {
                context.Users.AddOrUpdate(new Models.User()
                {
                    Login = $"loginn{userNumber}",
                    Password = $"p{userNumber}",
                    Age = DateTime.Now,
                    FirstName = $"loginn{userNumber}",
                    LastName = $"loginn{userNumber}",
                    Sex = "Ì",
                    Passport = "1111111111"
                });
            }
        }
    }
}
