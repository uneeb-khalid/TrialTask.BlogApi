using TrialTask.DataContracts;

namespace TrialTask.DAL
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User FindById(string id);
        User FindByEmail(string email);
        void Delete(string id);
        void Insert(User user);
        void Update(User user);
    }
}