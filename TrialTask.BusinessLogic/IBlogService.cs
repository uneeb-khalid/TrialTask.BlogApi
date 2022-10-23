using TrialTask.DataContracts;

namespace TrialTask.BusinessLogic
{
    public interface IBlogService
    {
        Blog Read(string id);
        IEnumerable<Blog> ReadAll();
        IEnumerable<Blog> GetLast10DaysBlogs();

        void AddNew(Blog blog);
        void Edit(Blog blog);
        void Delete(Blog blog);

        void CreateTag(Tag tag);
        void DeleteTag(Tag tag);
        IEnumerable<Tag> GetTags();
    }
}