using LiteDB;
using TrialTask.DataContracts;

namespace TrialTask.DAL
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> GetAll();
        public Blog GetById(string id);
        public void Insert(Blog blog);
        public void Delete(string id);
        void Update(Blog blog);

    }
}