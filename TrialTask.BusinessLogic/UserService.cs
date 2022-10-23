using TrialTask.DAL;
using TrialTask.DataContracts;

namespace TrialTask.BusinessLogic
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public void AddNew(User user)
        {
            user = user ?? throw new ArgumentNullException(nameof(user));
            userRepository.Insert(user);
        }

        public void Delete(User user)
        {
            user = user ?? throw new ArgumentNullException(nameof(user));
            userRepository.Delete(user.Id);
        }

        public void Edit(User user)
        {
            user = user ?? throw new ArgumentNullException(nameof(user));
            userRepository.Update(user);
        }

        public User Read(string id)
        {
            return userRepository.FindById(id);
        }

        public User ReadByEmail(string email)
        {
            return userRepository.FindByEmail(email);
        }

        public IEnumerable<User> ReadAll()
        {
           return userRepository.GetAll();
        }

        public bool Validate(User user)
        {
            // Passwords are not hashed and salted to keep the app simple
            var u = ReadByEmail(user.Email);
            return u != null && u.Password == user.Password;
        }
    }
}