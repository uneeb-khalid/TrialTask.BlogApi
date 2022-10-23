using TrialTask.Util.DI;
using System.Threading.Tasks.Dataflow;

namespace TrialTask.BusinessLogic
{
    public static class AssemblyInitializer
    {

        public static void Init(IDependencyRegistrator dependencyRegistrator)
        {
            TrialTask.DAL.AssemblyInitializer.Init(dependencyRegistrator);
            dependencyRegistrator.RegisterSingleton<IBlogService, BlogService>();
            dependencyRegistrator.RegisterSingleton<IUserService, UserService>();
            dependencyRegistrator.RegisterSingleton<IBlogPostingService, BlogPostingService>();
        }
    }
}
