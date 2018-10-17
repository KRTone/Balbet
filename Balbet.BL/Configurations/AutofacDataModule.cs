using Autofac;
using Balbet.BL.Interfaces;
using Balbet.BL.Services;
using Balbet.DAL.DbContext;
using Balbet.DAL.Interfaces;
using Balbet.DAL.Repositories;
using System;

namespace Balbet.BL.Configurations
{
    public class AutofacDataModule : Module
    {

        public AutofacDataModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<BusinessService>()
                .As<IBusinessService>()
                .InstancePerRequest();

            builder
                .RegisterType<RepositoryFactroy>()
                .As<IRepositoryFactory>()
                .InstancePerRequest();

            builder
                .RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .AsClosedTypesOf(typeof(IRepository<>))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder
                .RegisterType<DbContext>()
                .InstancePerRequest();

            base.Load(builder);
        }
    }
}
