using TrialTask.DataContracts;

namespace TrialTask.DAL
{
    public interface ICommentRepository
    {
        void Delete(string id);
        IEnumerable<Comment> GetAll(string postId);
        Comment GetById(string id);
        void Insert(Comment comment);
        void Update(Comment comment);
    }
}