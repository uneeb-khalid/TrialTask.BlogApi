using TrialTask.DataContracts;
using TrialTask.Util.DI;
using TrialTask.BusinessLogic;

namespace TrialTask.BusinessLogic.Test
{
    [TestClass]
    public class UserServiceTest
    {
        private IUserService _userService;

        [TestInitialize]
        public void Init()
        {
            var dm = DependencyManager.Instance as IDependencyResolver;
            _userService =  dm.Resolve<IUserService>();
        }  
        
        [TestMethod]
        public void Read_User_Test()
        {

            var user = _userService.Read("70F2E166-E5AB-4841-9B3C-88266070E69A");
            Assert.IsNotNull(user);

            Assert.IsTrue(!string.IsNullOrEmpty(user.Name));
            Assert.IsTrue(!string.IsNullOrEmpty(user.Email));
            Assert.IsTrue(!string.IsNullOrEmpty(user.Password));
        }
        [TestMethod]
        public void ReadByEmail_User_Test()
        {
            
            // Testing preexisting users
            var user = _userService.ReadByEmail("test@trialtest.com");
            Assert.IsNotNull(user);

            Assert.IsTrue(!string.IsNullOrEmpty(user.Name));
            Assert.IsTrue(!string.IsNullOrEmpty(user.Email));
            Assert.IsTrue(!string.IsNullOrEmpty(user.Password));
        }

        [TestMethod]
        public void AddNew_User_Test()
        {
            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Name = "ABC Test",
                Email = "test@trialtest.com",
                Password = "trialTest",
                LastModify = DateTime.Now,
            };

            _userService.AddNew(user);

            _userService.Delete(user);
        }
    }
}