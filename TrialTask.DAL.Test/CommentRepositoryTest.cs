using TrialTask.DataContracts;
using TrialTask.Util.DI;

namespace TrialTask.DAL.Test
{
    [TestClass]
    public class CommentRepositoryTest
    {
        private ICommentRepository _commentRepo;

        [TestInitialize]
        public void Init()
        {
            var dm = DependencyManager.Instance as IDependencyResolver;
            _commentRepo = dm.Resolve<ICommentRepository>();
        
        }

        [TestMethod]
        public void GetAll_Test()
        {

            IEnumerable<Comment> tags = _commentRepo.GetAll("F1F569A4-1469-4AAB-B3C4-8421D74E4869");

            Assert.IsNotNull(tags);
            Assert.IsTrue(tags.Count() >= 3);
            Assert.IsTrue(tags.Any(p => p.Id == "1D572E1E-78FB-4ABE-85C6-AE7C78CEA8B2"));
            Assert.IsTrue(tags.Any(p => p.Id == "1D572E1E-78FB-4ABE-85C6-AE7C78CEA8B3"));
            Assert.IsTrue(tags.Any(p => p.Id == "1D572E1E-78FB-4ABE-85C6-AE7C78CEA8B4"));
        }
        
        [TestMethod]
        public void Insert_Test()
        {
            var newComment = new Comment { Id = Guid.NewGuid().ToString(), Content = "Test comment 1", PostId = "F1F569A4-1469-4AAB-B3C4-8421D74E4869", LastModify = DateTime.Now };
            _commentRepo.Insert(newComment);

            var insertedComment = _commentRepo.GetById(newComment.Id);
            
            _commentRepo.Delete(insertedComment.Id);

            Assert.IsNotNull(insertedComment);
            Assert.IsTrue(insertedComment.Id == newComment.Id);
            Assert.IsTrue(insertedComment.Content == newComment.Content);


        }

        [TestMethod]
        public void Delete_Test()
        {
            var newComment = new Comment { Id = Guid.NewGuid().ToString(), Content = "Test comment 1", PostId = "F1F569A4-1469-4AAB-B3C4-8421D74E4869", LastModify = DateTime.Now };
            _commentRepo.Insert(newComment);

            _commentRepo.Delete(newComment.Id);

            var deletedComment = _commentRepo.GetById(newComment.Id);

            Assert.IsNull(deletedComment);
        }
    }
}