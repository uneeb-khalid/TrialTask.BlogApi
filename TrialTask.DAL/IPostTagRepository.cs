using TrialTask.DataContracts;

namespace TrialTask.DAL
{
    public interface IPostTagRepository
    {
        void Delete(string id);
        IEnumerable<PostTag> GetAll(string postId);
        Tag GetById(string id);
        void Insert(PostTag postTag);
        void Update(PostTag tag);
    }
}