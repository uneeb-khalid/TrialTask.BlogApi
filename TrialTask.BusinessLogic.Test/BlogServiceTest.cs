using TrialTask.DataContracts;
using TrialTask.Util.DI;
using TrialTask.BusinessLogic;

namespace TrialTask.BusinessLogic.Test
{

    [TestClass]
    public class BlogServiceTest
    {
        private IBlogService _blogService;

        [TestInitialize]
        public void Init()
        {
            var dm = DependencyManager.Instance as IDependencyResolver;
            _blogService = dm.Resolve<IBlogService>();
        }

        [TestMethod]
        public void ReadAll_Blogs_Test()
        {
            var blogs = _blogService.ReadAll();
            Assert.IsNotNull(blogs);
            Assert.IsTrue(blogs.Count() >= 2);
        }

        [TestMethod]
        public void Atleast_Two_Last_10Days_Blogs_Test()
        {
            var blog = new Blog
            {
                Id = Guid.NewGuid().ToString(),
                Name = "UnitTest blog",
                Description = "This blog is added for testing purpose blog",
                CreationDate = DateTime.Now.AddDays(-11),
            };

            var blog2 = new Blog
            {
                Id = Guid.NewGuid().ToString(),
                Name = "UnitTest blog",
                Description = "This blog is added for testing purpose blog",
                CreationDate = DateTime.Now.AddDays(-9),
            };
            var blog3 = new Blog
            {
                Id = Guid.NewGuid().ToString(),
                Name = "UnitTest blog",
                Description = "This blog is added for testing purpose blog",
                CreationDate = DateTime.Now.AddDays(-1),
            };

            _blogService.AddNew(blog);
            _blogService.AddNew(blog2);
            _blogService.AddNew(blog3);


            var last10DaysBlogs = _blogService.GetLast10DaysBlogs();


            _blogService.Delete(blog);
            _blogService.Delete(blog2);
            _blogService.Delete(blog3);

            Assert.IsNotNull(last10DaysBlogs);
            Assert.IsTrue(last10DaysBlogs.Count() >= 2);

        }

        [TestMethod]
        public void AddNew_Blog_Test()
        {
            var blog = new Blog
            {
                Id = Guid.NewGuid().ToString(),
                Name = "UnitTest blog",
                Description = "This blog is added for testing purpose blog",
                CreationDate = DateTime.Now,
            };

            _blogService.AddNew(blog);
        }
        [TestMethod]
        public void Edit_Blog_Test()
        {
            var blog = new Blog { Id = "97B41C18-7E29-4F92-A96C-D8066895D9A7", Name = "Blog 1 Edited", Description = "Test blog 1 description edited" };
            var b = _blogService.Read(blog.Id);
            b.Name = blog.Name;
            b.Description = blog.Description;

            _blogService.Edit(blog);
        }
        [TestMethod]
        public void Delete_Blog_Test()
        {
            var blog = new Blog
            {
                Id = "97B41C18-7E29-4F92-A96C-D8066895D9A7",
                Name = "Blog 1 Edited",
                Description = "Test blog 1 description edited",
                UserId = "70F2E166-E5AB-4841-9B3C-88266070E69A",
                CreationDate = DateTime.Now
            };

            _blogService.Delete(blog);

            _blogService.AddNew(blog);
        }


        [TestMethod]
        public void Create_Tag_Test()
        {
            var tag = new Tag
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Test tag",
            };

            _blogService.CreateTag(tag);

            _blogService.DeleteTag(tag);
        }

        [TestMethod]
        public void GetTags_Test()
        {
            var tag1 = new Tag
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Test tag 1",
            };
            var tag2 = new Tag
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Test tag 2",
            };

            _blogService.CreateTag(tag1);
            _blogService.CreateTag(tag2);

            var tags = _blogService.GetTags();

            _blogService.DeleteTag(tag1);
            _blogService.DeleteTag(tag2);

            Assert.IsNotNull(tags);
            Assert.IsTrue(tags.Count() >= 2);

        }


    }
}