using TrialTask.DataContracts;

namespace TrialTask.DAL
{
    public interface ITagRepository
    {
        void Delete(string id);
        IEnumerable<Tag> GetAll();
        Tag GetById(string id);
        void Insert(Tag tags);
        void Update(Tag tag);
    }
}