using Balbet.DAL.ModelsDTO;

namespace Balbet.DAL.Interfaces
{
    public interface IRepositoryFactory
    {
        IRepository<UserDTO> GetUserRepository();
    }
}
