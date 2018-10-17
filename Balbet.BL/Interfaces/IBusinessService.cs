using System.Linq;
using Balbet.BL.ModelsDTO;

namespace Balbet.BL.Interfaces
{
    public interface IBusinessService
    {
        IQueryable<UserDTO> GetUsers();
        UserDTO GetUserByLogin(string login);
        IQueryable<UserDTO> PagingUsers(int skip, int take);
        UserDTO AddUser(UserDTO userModel);
        void DeleteUser(string login);
        UserDTO EditUser(UserDTO userModel);
    }
}
