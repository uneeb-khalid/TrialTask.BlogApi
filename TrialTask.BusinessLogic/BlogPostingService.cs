using TrialTask.DAL;
using TrialTask.DataContracts;

namespace TrialTask.BusinessLogic
{
    internal class BlogPostingService : IBlogPostingService
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IPostTagRepository postTagRepository;
        private readonly ITagRepository tagRepository;
        private readonly ICommentRepository commentRepository;

        public BlogPostingService(IBlogPostRepository blogPostRepository,
                                  IPostTagRepository pstTagRepository,
                                  ITagRepository tagRepository,
                                  ICommentRepository commentRepository)
        {
            this.blogPostRepository = blogPostRepository;
            this.postTagRepository = pstTagRepository;
            this.tagRepository = tagRepository;
            this.commentRepository = commentRepository;
        }


        public IEnumerable<BlogPost> ReadAll(string blogID) => blogPostRepository.GetAll(blogID);
        public BlogPost Read(string id)
        {
            id = id ?? throw new ArgumentNullException(nameof(id));
            return blogPostRepository.GetById(id);
        }
        public IEnumerable<BlogPost> GetLast30DaysPosts(string blogId)
        {
            return blogPostRepository.GetAll(blogId).Where(blog => blog.CreationDateTime.Date >= DateTime.Now.AddDays(-30).Date);
        }
        public void AddNew(BlogPost blogPost)
        {
            blogPost = blogPost ?? throw new ArgumentNullException(nameof(blogPost));
            blogPostRepository.Insert(blogPost);
        }

        public void Edit(BlogPost blogPost)
        {
            blogPost = blogPost ?? throw new ArgumentNullException(nameof(blogPost));
            blogPostRepository.Update(blogPost);
        }

        public void Delete(BlogPost blog)
        {
            blog = blog ?? throw new ArgumentNullException(nameof(blog));
            blogPostRepository.Delete(blog.Id);
        }

        #region tags
        public IEnumerable<Tag> GetTags(string postID)
        {
            postID = postID ?? throw new ArgumentNullException(nameof(postID));
            var postTags = postTagRepository.GetAll(postID);
            if(postTags.Any())
            {
                var tags = new List<Tag>();
                foreach (var tag in postTags)
                {
                    tags.AddRange( tagRepository.GetAll().Where(t => t.Id == tag.TagId));

                }
                return tags;
            }
            return new List<Tag>();
        }
        public void AddTag(PostTag postTag)
        {
            postTag = postTag ?? throw new ArgumentNullException(nameof(postTag));
            postTagRepository.Insert(postTag);
        }
        public void RemoveTag(PostTag postTag)
        {
            postTag = postTag ?? throw new ArgumentNullException(nameof(postTag));
            postTagRepository.Delete(postTag.Id);
        }
        #endregion
        #region comments
        public IEnumerable<Comment> GetComments(string postId)
        {
            postId = postId ?? throw new ArgumentNullException(nameof(postId));
            return commentRepository.GetAll(postId);
        }
        public Comment GetComment(string Id)
        {
            Id = Id ?? throw new ArgumentNullException(nameof(Id));
            return commentRepository.GetById(Id);
        }
        public void AddComment(Comment comment)
        {
            comment = comment ?? throw new ArgumentNullException(nameof(comment));
            commentRepository.Insert(comment);
        }
        public void DeleteComment(Comment comment)
        {
            comment = comment ?? throw new ArgumentNullException(nameof(comment));
            commentRepository.Delete(comment.Id);
        }

        public void EditComment(Comment comment)
        {
            comment = comment ?? throw new ArgumentNullException(nameof(comment));
            commentRepository.Update(comment);
        }

        #endregion
    }
}