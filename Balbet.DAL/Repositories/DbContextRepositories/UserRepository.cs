using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Balbet.DAL.Interfaces;
using Balbet.DAL.Models;
using Balbet.DAL.ModelsDTO;
using AutoMapper;

namespace Balbet.DAL.Repositories.DbContextRepositories
{
    public class UserRepository : BaseRepository<UserDTO>
    {
        public UserRepository(DbContext.DbContext connectionString) : base(connectionString)
        { }

        public override UserDTO Get(string login)
        {
            var user = DataContext.Users.Where(w => w.Login == login).FirstOrDefault();
            return Mapper.Map<User, UserDTO>(user);
        }

        public override UserDTO Add(UserDTO model)
        {
            DataContext.Users.Add(Mapper.Map<UserDTO, User>(model));
            DataContext.SaveChanges();
            return model;
        }


        public override void Delete(string login)
        {
            DataContext.Users.Remove(DataContext.Users.Where(w => w.Login == login).FirstOrDefault());
            DataContext.SaveChanges();
        }

        public override UserDTO Update(UserDTO model)
        {
            var newModel = Mapper.Map<UserDTO, User>(model);
            var modified = DataContext.Users.First(f => f.Login == newModel.Login);
            modified.Age = newModel.Age;
            modified.FirstName = newModel.FirstName;
            modified.LastName = newModel.LastName;
            modified.Passport = newModel.Passport;
            modified.Password = newModel.Password;
            modified.Sex = newModel.Sex;
            DataContext.SaveChanges();
            return Mapper.Map<UserDTO>(modified);
        }

        public override IQueryable<UserDTO> Get() =>
            Mapper.Map<System.Collections.Generic.List<UserDTO>>(DataContext.Users).AsQueryable();

        public override IQueryable<UserDTO> Paging(int skip, int take) =>
            Mapper.Map<List<UserDTO>>(DataContext.Users
                .OrderBy(user => user.Login)
                .Skip(skip)
                .Take(take)).AsQueryable();
    }
}
