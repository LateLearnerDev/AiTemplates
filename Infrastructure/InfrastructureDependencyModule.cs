using Application.Common.Interfaces;
using Application.Common.Services;
using Autofac;
using Infrastructure.Ioc;
using Infrastructure.Services;
using Infrastructure.Storage.Persistence.Context;
using Infrastructure.Storage.Persistence.Repository;

namespace Infrastructure;

public class InfrastructureDependencyModule : DependencyResolvingModule
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<AiTemplatesDbContext>().InstancePerLifetimeScope();
        builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
        
        builder.RegisterType<OpenAiService>()
            .As<IOpenAiService>()
            .InstancePerLifetimeScope();    
    }
}