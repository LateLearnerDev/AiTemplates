using Application.Assistants.Services;
using Application.Common.Interfaces;
using Application.Completions.Services;
using Application.Messages.Services;
using Application.Threads.Services;
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
        
        builder.RegisterType<CompletionService>()
            .As<ICompletionService>()
            .InstancePerLifetimeScope(); 
        builder.RegisterType<AssistantService>()
            .As<IAssistantService>()
            .InstancePerLifetimeScope(); 
        builder.RegisterType<ThreadService>()
            .As<IThreadService>()
            .InstancePerLifetimeScope();
        builder.RegisterType<MessageService>()
            .As<IMessageService>()
            .InstancePerLifetimeScope();
    }
}