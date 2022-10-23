using TrialTask.DAL;
using TrialTask.DataContracts;
using TrialTask.Util.DI;

namespace TrialTask.BusinessLogic.Test
{
    [TestClass]
    public class TestInitializer
    {

        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
            var dm = DependencyManager.Instance;
            AssemblyInitializer.Init(dm);

            dm.RegisterSingleton(new DbConfig { Database = "TestDb.db" });
            dm.CompleteRegistration();
            SeedUp();
        }



        public static void SeedUp()
        {
            var dm = DependencyManager.Instance;
            var blogRepo = dm.Resolve<IBlogRepository>();
            var blogPostRepo = dm.Resolve<IBlogPostRepository>();
            var userRepo = dm.Resolve<IUserRepository>();
            if (!userRepo.GetAll().Any())
            {
                var user = new User
                {
                    Id = "70F2E166-E5AB-4841-9B3C-88266070E69A",
                    Name = "ABC Test",
                    Email = "test@trialtest.com",
                    Password = "trialTest",
                    LastModify = DateTime.Now,
                };

                userRepo.Insert(user);

                if (!blogRepo.GetAll().Any())
                {
                    blogRepo.Insert(new Blog { Id = "97B41C18-7E29-4F92-A96C-D8066895D9A7", Name = "Blog 1", Description = "Test blog 1", CreationDate = DateTime.Now, UserId = user.Id });
                    blogRepo.Insert(new Blog { Id = "4DA4D59D-5CF7-4305-8080-EA16F50416E5", Name = "Blog 2", Description = "Test blog 2", CreationDate = DateTime.Now.AddDays(-1), UserId = user.Id });

                    var blogPost1 = new BlogPost
                    {
                        Id = "F1F569A4-1469-4AAB-B3C4-8421D74E4869",
                        BlogId = "97B41C18-7E29-4F92-A96C-D8066895D9A7",
                        userId = "70F2E166-E5AB-4841-9B3C-88266070E69A",
                        Title = "UnitTest blog 1",
                        Content = "This blog is added for testing purpose blog",
                        CreationDateTime = DateTime.Now,
                    };

                    var blogPost2 = new BlogPost
                    {
                        Id = "F1F569A4-1469-4AAB-B3C4-8421D74E4860",
                        BlogId = "97B41C18-7E29-4F92-A96C-D8066895D9A7",
                        userId = "70F2E166-E5AB-4841-9B3C-88266070E69A",
                        Title = "UnitTest blog 2",
                        Content = "This blog is added for testing purpose blog",
                        CreationDateTime = DateTime.Now.AddDays(-11),
                    };
                    var blogPost3 = new BlogPost
                    {
                        Id = "F1F569A4-1469-4AAB-B3C4-8421D74E4861",
                        BlogId = "97B41C18-7E29-4F92-A96C-D8066895D9A7",
                        userId = "70F2E166-E5AB-4841-9B3C-88266070E69A",
                        Title = "UnitTest blog 3",
                        Content = "This blog is added for testing purpose blog",
                        CreationDateTime = DateTime.Now.AddDays(-31),
                    };

                    blogPostRepo.Insert(blogPost1);
                    blogPostRepo.Insert(blogPost2);
                    blogPostRepo.Insert(blogPost3);
                }
            }
        }
    }
}
