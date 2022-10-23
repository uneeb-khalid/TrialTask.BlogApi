using Autofac;

namespace TrialTask.Util.DI
{
    public class DependencyManager : IDependencyRegistrator, IDependencyResolver
    {
        private ContainerBuilder builder;
        private IContainer _container;

        public static DependencyManager Instance { get; private set; } = new DependencyManager();

        private DependencyManager()
        {
            builder = new ContainerBuilder();
        }
        public void AddContainerBuilder(ContainerBuilder containerBuilder)
        {
            builder = containerBuilder;
        }

        public void RegisterSingleton<TType>(TType instance)
            where TType : class
        {
            _ = builder.RegisterInstance(instance);
        }
        public void RegisterSingleton<TInterface, TType>()
        {
            _ = builder.RegisterType<TType>().As<TInterface>().SingleInstance();
        }
        public void RegisterTransient<TInterface, TType>()
             where TType : class, TInterface

        {
            _ = builder.RegisterType<TType>().As<TInterface>();
        }

        public IContainer CompleteRegistration()
        {
           return _container = builder.Build();
        }
        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    
    }
}
