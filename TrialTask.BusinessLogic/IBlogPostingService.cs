using TrialTask.DataContracts;

namespace TrialTask.BusinessLogic
{
    public interface IBlogPostingService
    {
        void AddNew(BlogPost blogPost);
        void Delete(BlogPost blog);
        void Edit(BlogPost blogPost);
        BlogPost Read(string id);
        IEnumerable<BlogPost> ReadAll(string blogID);

        IEnumerable<Tag> GetTags(string postID);
        void AddTag(PostTag tag);
        void RemoveTag(PostTag postTag);

        void AddComment(Comment comment);
        void DeleteComment(Comment comment);
        void EditComment(Comment comment);
        IEnumerable<BlogPost> GetLast30DaysPosts(string blogId);
        IEnumerable<Comment> GetComments(string postId);
        Comment GetComment(string Id);
       
    }
}