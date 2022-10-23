namespace TrialTask.Util.DI
{
    public interface IDependencyResolver
    {
        TType Resolve<TType>();
    }
}
