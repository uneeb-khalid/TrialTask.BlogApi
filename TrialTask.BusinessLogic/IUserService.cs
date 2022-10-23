using TrialTask.DataContracts;

namespace TrialTask.BusinessLogic
{
    public interface IUserService
    {
        User Read(string id);
        User ReadByEmail(string email);
        IEnumerable<User> ReadAll();
        bool Validate(User user);
        void AddNew(User user);
        void Edit(User user);
        void Delete(User user);
    }
}