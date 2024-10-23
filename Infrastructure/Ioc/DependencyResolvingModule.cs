using Autofac;

namespace Infrastructure.Ioc;

public class DependencyResolvingModule : Module
{
    public int Order { get; set; } = 0;
}