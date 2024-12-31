using Application.Common.Interfaces;
using Application.OpenAi.Assistants.Services;
using Application.OpenAi.Completions.Services;
using Application.OpenAi.Messages.Services;
using Application.OpenAi.Runs.Services;
using Application.OpenAi.Threads.Services;
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
        builder.RegisterType<RunService>()
            .As<IRunService>()
            .InstancePerLifetimeScope();
    }
}