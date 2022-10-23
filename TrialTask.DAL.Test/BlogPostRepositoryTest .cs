using TrialTask.DataContracts;
using TrialTask.Util.DI;

namespace TrialTask.DAL.Test
{
    [TestClass]
    public class BlogPostRepositoryTest
    {
        private IBlogPostRepository _blogPostRepo;


        [TestInitialize]
        public void Init()
        {
            var dm = DependencyManager.Instance as IDependencyResolver;
            _blogPostRepo = dm.Resolve<IBlogPostRepository>();
        }


        [TestMethod]
        public void GetAll_Test()
        {
            IEnumerable<BlogPost> blogs = _blogPostRepo.GetAll("97B41C18-7E29-4F92-A96C-D8066895D9A7");

            Assert.IsNotNull(blogs);
            Assert.IsTrue(blogs.Count() >= 3); 
            Assert.IsTrue(blogs.Any(p =>  p.Id == "F1F569A4-1469-4AAB-B3C4-8421D74E4869")); 
            Assert.IsTrue(blogs.Any(p =>  p.Id == "F1F569A4-1469-4AAB-B3C4-8421D74E4860")); 
            Assert.IsTrue(blogs.Any(p =>  p.Id == "F1F569A4-1469-4AAB-B3C4-8421D74E4861")); 
        }
        
        [TestMethod]
        public void Insert_Test()
        {
            string id = Guid.NewGuid().ToString();
            string title = "my Test Blog Post";
            var blogPost1 = new BlogPost
            {
                Id = id,
                BlogId = "97B41C18-7E29-4F92-A96C-D8066895D9A7",
                userId = "70F2E166-E5AB-4841-9B3C-88266070E69A",
                Title = title,
                Content = "This blog is added for testing purpose blog",
                CreationDateTime = DateTime.Now,
            };

            _blogPostRepo.Insert(blogPost1);

            var insertedBlog = _blogPostRepo.GetById(id);

            Assert.IsNotNull(insertedBlog);
            Assert.IsTrue(insertedBlog.Id == id);
            Assert.IsTrue(insertedBlog.Title == title);

            _blogPostRepo.Delete(id);
        }

        [TestMethod]
        public void Delete_Test()
        {
            string id = Guid.NewGuid().ToString();
            string title = "my Test Blog Post";
            var blogPost1 = new BlogPost
            {
                Id = id,
                BlogId = "97B41C18-7E29-4F92-A96C-D8066895D9A7",
                userId = "70F2E166-E5AB-4841-9B3C-88266070E69A",
                Title = title,
                Content = "This blog is added for testing purpose blog",
                CreationDateTime = DateTime.Now,
            };

            _blogPostRepo.Insert(blogPost1);

            _blogPostRepo.Delete(id);

            var deletedBlog = _blogPostRepo.GetById(id);

            Assert.IsNull(deletedBlog);
        }
    }
}