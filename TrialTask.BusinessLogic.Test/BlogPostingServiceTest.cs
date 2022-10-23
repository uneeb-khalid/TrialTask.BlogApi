using TrialTask.DataContracts;
using TrialTask.Util.DI;
using TrialTask.BusinessLogic;

namespace TrialTask.BusinessLogic.Test
{

    [TestClass]
    public class BlogPostingServiceTest
    {
        private IBlogPostingService _blogPostService;

        [TestInitialize]
        public void Init()
        {
            var dm = DependencyManager.Instance as IDependencyResolver;
            _blogPostService = dm.Resolve<IBlogPostingService>();
        }


        [TestMethod]
        public void Last_30Days_BlogPosts_Test()
        {
            var blog = new BlogPost
            {
                Id = Guid.NewGuid().ToString(),
                BlogId = "97B41C18-7E29-4F92-A96C-D8066895D9A7",
                userId = "70F2E166-E5AB-4841-9B3C-88266070E69A",
                Title = "UnitTest blog 1",
                Content = "This blog is added for testing purpose blog",
                CreationDateTime = DateTime.Now,
            };

            var blog2 = new BlogPost
            {
                Id = Guid.NewGuid().ToString(),
                BlogId = "97B41C18-7E29-4F92-A96C-D8066895D9A7",
                userId = "70F2E166-E5AB-4841-9B3C-88266070E69A",
                Title = "UnitTest blog 2",
                Content = "This blog is added for testing purpose blog",
                CreationDateTime = DateTime.Now.AddDays(-11),
            };
            var blog3 = new BlogPost
            {
                Id = Guid.NewGuid().ToString(),
                BlogId = "97B41C18-7E29-4F92-A96C-D8066895D9A7",
                userId = "70F2E166-E5AB-4841-9B3C-88266070E69A",
                Title = "UnitTest blog 3",
                Content = "This blog is added for testing purpose blog",
                CreationDateTime = DateTime.Now.AddDays(-31),
            };

            _blogPostService.AddNew(blog);
            _blogPostService.AddNew(blog2);
            _blogPostService.AddNew(blog3);


            var last30DaysPosts = _blogPostService.GetLast30DaysPosts(blog.BlogId);

            _blogPostService.Delete(blog);
            _blogPostService.Delete(blog2);
            _blogPostService.Delete(blog3);

            Assert.IsNotNull(last30DaysPosts);
            Assert.IsTrue(last30DaysPosts.Count() >= 2);
            Assert.IsTrue(last30DaysPosts.Any(bp => bp.Id == blog.Id));
            Assert.IsTrue(last30DaysPosts.Any(bp => bp.Id == blog2.Id));
            Assert.IsFalse(last30DaysPosts.Any(bp => bp.Id == blog3.Id));

        }

        [TestMethod]
        public void ReadAll_Test()
        {
            var blog = new BlogPost
            {
                Id = Guid.NewGuid().ToString(),
                BlogId = "97B41C18-7E29-4F92-A96C-D8066895D9A7",
                userId = "70F2E166-E5AB-4841-9B3C-88266070E69A",
                Title = "UnitTest blog 1",
                Content = "This blog is added for testing purpose blog",
                CreationDateTime = DateTime.Now,
            };

            var blog2 = new BlogPost
            {
                Id = Guid.NewGuid().ToString(),
                BlogId = "97B41C18-7E29-4F92-A96C-D8066895D9A7",
                userId = "70F2E166-E5AB-4841-9B3C-88266070E69A",
                Title = "UnitTest blog 2",
                Content = "This blog is added for testing purpose blog",
                CreationDateTime = DateTime.Now.AddDays(-11),
            };
            var blog3 = new BlogPost
            {
                Id = Guid.NewGuid().ToString(),
                BlogId = "97B41C18-7E29-4F92-A96C-D8066895D9A7",
                userId = "70F2E166-E5AB-4841-9B3C-88266070E69A",
                Title = "UnitTest blog 3",
                Content = "This blog is added for testing purpose blog",
                CreationDateTime = DateTime.Now.AddDays(-31),
            };

            _blogPostService.AddNew(blog);
            _blogPostService.AddNew(blog2);
            _blogPostService.AddNew(blog3);


            var allPosts = _blogPostService.ReadAll(blog.BlogId);

            _blogPostService.Delete(blog);
            _blogPostService.Delete(blog2);
            _blogPostService.Delete(blog3);

            Assert.IsNotNull(allPosts);
            Assert.IsTrue(allPosts.Count() >= 2);
            Assert.IsTrue(allPosts.Any(bp => bp.Id == blog.Id));
            Assert.IsTrue(allPosts.Any(bp => bp.Id == blog2.Id));
            Assert.IsTrue(allPosts.Any(bp => bp.Id == blog3.Id));

        } 
        
        [TestMethod]
        public void AddNew_Post_Test()
        {
            var post = new BlogPost
            {
                Id = Guid.NewGuid().ToString(),
                BlogId = "97B41C18-7E29-4F92-A96C-D8066895D9A7",
                userId = "70F2E166-E5AB-4841-9B3C-88266070E69A",
                Title = "UnitTest blog 1",
                Content = "This blog is added for testing purpose blog",
                CreationDateTime = DateTime.Now,
            };

            _blogPostService.AddNew(post);

            var fetchedPost = _blogPostService.ReadAll(post.BlogId).SingleOrDefault(p => p.Id == post.Id);

            _blogPostService.Delete(fetchedPost);


            Assert.IsNotNull(fetchedPost);
            Assert.IsTrue(fetchedPost.Id == post.Id);

        }
        
        [TestMethod]
        public void Edit_Post_Test()
        {
            var post = new BlogPost
            {
                Id = Guid.NewGuid().ToString(),
                BlogId = "97B41C18-7E29-4F92-A96C-D8066895D9A7",
                userId = "70F2E166-E5AB-4841-9B3C-88266070E69A",
                Title = "UnitTest blog 1",
                Content = "This blog is added for testing purpose blog",
                CreationDateTime = DateTime.Now,
            };

            _blogPostService.AddNew(post);
            var fetchedPost = _blogPostService.ReadAll(post.BlogId).SingleOrDefault(p => p.Id == post.Id);

            fetchedPost.Title = "Edited Title";
            fetchedPost.Content = "Edited Contents";

            _blogPostService.Edit(fetchedPost);

            var editedPost = _blogPostService.ReadAll(post.BlogId).SingleOrDefault(p => p.Id == fetchedPost.Id);

            Assert.IsNotNull(editedPost);
            Assert.IsTrue(fetchedPost.Title == editedPost.Title);
            Assert.IsTrue(fetchedPost.Content == editedPost.Content);

            _blogPostService.Delete(post);

        }
                
        [TestMethod]
        public void Delete_Post_Test()
        {
            var post = new BlogPost
            {
                Id = Guid.NewGuid().ToString(),
                BlogId = "97B41C18-7E29-4F92-A96C-D8066895D9A7",
                userId = "70F2E166-E5AB-4841-9B3C-88266070E69A",
                Title = "UnitTest blog 1",
                Content = "This blog is added for testing purpose blog",
                CreationDateTime = DateTime.Now,
            };

            _blogPostService.AddNew(post);
            _blogPostService.Delete(post);

            var fetchedPost = _blogPostService.ReadAll(post.BlogId).SingleOrDefault(p => p.Id == post.Id);

            Assert.IsNull(fetchedPost);
        }

    }
}