namespace TrialTask.Util.DI
{
    public interface IDependencyRegistrator
    {
        void RegisterSingleton<TInterface, TType>();
        void RegisterSingleton<TType>(TType instance) where TType : class;
        void RegisterTransient<TInterface, TType>() where TType : class, TInterface;

    }
}