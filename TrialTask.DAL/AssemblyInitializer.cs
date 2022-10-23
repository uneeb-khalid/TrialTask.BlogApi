using TrialTask.Util.DI;

namespace TrialTask.DAL
{
    public static class AssemblyInitializer
    {
        public static void Init(IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator.RegisterSingleton(new DbConfig { Database = "ProdDb.db" });

            dependencyRegistrator.RegisterTransient<IUserRepository, UserRepository>();
            dependencyRegistrator.RegisterTransient<IBlogRepository, BlogRepository>();
            dependencyRegistrator.RegisterTransient<IBlogPostRepository, BlogPostRepository>();
            dependencyRegistrator.RegisterTransient<ITagRepository, TagRepository>();
            dependencyRegistrator.RegisterTransient<IPostTagRepository, PostTagRepository>();
            dependencyRegistrator.RegisterTransient<ICommentRepository, CommentRepository>();
        }
    }
}
