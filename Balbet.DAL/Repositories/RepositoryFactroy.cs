using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Balbet.DAL.Interfaces;
using Autofac;
using Balbet.DAL.ModelsDTO;

namespace Balbet.DAL.Repositories
{
    public class RepositoryFactroy : IRepositoryFactory
    {
        readonly ILifetimeScope lifeTimeScope;

        public RepositoryFactroy(ILifetimeScope lifeTimeScope)
        {
            this.lifeTimeScope = lifeTimeScope;
        }
        public IRepository<UserDTO> GetUserRepository()
        {
            return lifeTimeScope.Resolve<DbContextRepositories.UserRepository>();
        }
    }
}
