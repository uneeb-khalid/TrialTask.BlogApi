using TrialTask.DataContracts;
using TrialTask.Util.DI;

namespace TrialTask.DAL.Test
{
    [TestClass]
    public class TagRepositoryTest
    {
        private ITagRepository _tagRepo;

        [TestInitialize]
        public void Init()
        {
            var dm = DependencyManager.Instance as IDependencyResolver;
            _tagRepo = dm.Resolve<ITagRepository>();
        }

        [TestMethod]
        public void GetAll_Test()
        {
            IEnumerable<Tag> tags = _tagRepo.GetAll();

            Assert.IsNotNull(tags);
            Assert.IsTrue(tags.Count() >= 3); 
            Assert.IsTrue(tags.Any(p =>  p.Id == "49C9F8AE-53F1-49EF-A5F0-4DCCBA3C4C26")); 
            Assert.IsTrue(tags.Any(p =>  p.Id == "49C9F8AE-53F1-49EF-A5F0-4DCCBA3C4C27")); 
            Assert.IsTrue(tags.Any(p =>  p.Id == "49C9F8AE-53F1-49EF-A5F0-4DCCBA3C4C28")); 
        }
        
        [TestMethod]
        public void Insert_Test()
        {
            var newTag = new Tag { Id = Guid.NewGuid().ToString(), Name = "Tag1" };

            _tagRepo.Insert(newTag);

            var insertedTag = _tagRepo.GetById(newTag.Id);
            
            _tagRepo.Delete(insertedTag.Id);

            Assert.IsNotNull(insertedTag);
            Assert.IsTrue(insertedTag.Id == newTag.Id);
            Assert.IsTrue(insertedTag.Name == newTag.Name);


        }

        [TestMethod]
        public void Delete_Test()
        {
            var newTag = new Tag { Id = Guid.NewGuid().ToString(), Name = "Tag1" };
            string id = newTag.Id;

            _tagRepo.Insert(newTag);
            _tagRepo.Delete(id);

            var deletedBlog = _tagRepo.GetById(id);

            Assert.IsNull(deletedBlog);
        }
    }
}