using TrialTask.DataContracts;

namespace TrialTask.DAL
{
    public interface IBlogPostRepository
    {
        void Delete(string id);
        IEnumerable<BlogPost> GetAll(string blogId);
        BlogPost GetById(string id);
        void Insert(BlogPost blog);
        void Update(BlogPost blogPost);
    }
}