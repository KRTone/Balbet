using System.Collections.Generic;
using System.Linq;
using Balbet.BL.ModelsDTO;
using Balbet.DAL.Interfaces;
using AutoMapper;
using Balbet.BL.Interfaces;

namespace Balbet.BL.Services
{
    public class BusinessService : IBusinessService
    {
        IRepositoryFactory RepositoryFactory { get; }

        public BusinessService(IRepositoryFactory repFactory)
        {
            this.RepositoryFactory = repFactory;
        }

        public IQueryable<UserDTO> GetUsers()
        {
            return Mapper.Map<List<UserDTO>>(this.RepositoryFactory.GetUserRepository().Get()).AsQueryable();
        }
                

        public UserDTO GetUserByLogin(string login)
        {
            return Mapper.Map<UserDTO>(this.RepositoryFactory.GetUserRepository().Get(login));
        }

        public IQueryable<UserDTO> PagingUsers(int skip, int take)
        {
            return Mapper.Map<List<UserDTO>>(this.RepositoryFactory.GetUserRepository().Paging(skip,take)).AsQueryable();
        }

        public UserDTO AddUser(UserDTO userModel)
        {
            return Mapper.Map<UserDTO>(this.RepositoryFactory.GetUserRepository().Add(Mapper.Map<UserDTO,Balbet.DAL.ModelsDTO.UserDTO>(userModel)));
        }

        public void DeleteUser(string login)
        {
            this.RepositoryFactory.GetUserRepository().Delete(login);
        }

        public UserDTO EditUser(UserDTO userModel)
        {
            return Mapper.Map<UserDTO>(this.RepositoryFactory.GetUserRepository().Update(Mapper.Map<UserDTO, Balbet.DAL.ModelsDTO.UserDTO>(userModel)));
        }
    }
}
