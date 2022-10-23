using TrialTask.DataContracts;
using TrialTask.Util.DI;

namespace TrialTask.DAL.Test
{
    [TestClass]
    public class BlogRepositoryTest
    {
        private IBlogRepository _blogRepo;


        [TestInitialize]
        public void Init()
        {
            var dm = DependencyManager.Instance as IDependencyResolver;
            _blogRepo = dm.Resolve<IBlogRepository>();
        }


        [TestMethod]
        public void GetAll_Test()
        {
            IEnumerable<Blog> blogs = _blogRepo.GetAll();

            Assert.IsNotNull(blogs);
            Assert.IsTrue(blogs.Any()); 
        }
        
        [TestMethod]
        public void Insert_Test()
        {
            string id = Guid.NewGuid().ToString();
            string name = "my Test Blog";

            _blogRepo.Insert(new Blog { Id = id, Name = name, Description = "Inserted for testing purpose", CreationDate = DateTime.Now });

            var insertedBlog = _blogRepo.GetById(id);

            Assert.IsNotNull(insertedBlog);
            Assert.IsTrue(insertedBlog.Id == id);
            Assert.IsTrue(insertedBlog.Name == name);

            _blogRepo.Delete(id);
        }

        [TestMethod]
        public void Delete_Test()
        {
            string id = Guid.NewGuid().ToString();
            string name = "my Test Blog";

            _blogRepo.Insert(new Blog { Id = id, Name = name, Description = "Inserted for testing purpose", CreationDate = DateTime.Now });
            _blogRepo.Delete(id);

            var deletedBlog = _blogRepo.GetById(id);

            Assert.IsNull(deletedBlog);
        }
    }
}