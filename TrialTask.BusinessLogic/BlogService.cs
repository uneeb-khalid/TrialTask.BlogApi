using TrialTask.DAL;
using TrialTask.DataContracts;

namespace TrialTask.BusinessLogic
{
    internal class BlogService : IBlogService
    {
        private readonly IBlogRepository blogRepository;
        private readonly ITagRepository tagRepository;

        public BlogService(IBlogRepository blogRepository, ITagRepository tagRepository)
        {
            this.blogRepository = blogRepository;
            this.tagRepository = tagRepository;
        }
        public void AddNew(Blog blog)
        {
            blog = blog ?? throw new ArgumentNullException(nameof(blog));
            blogRepository.Insert(blog);
        }
    
        public void Edit(Blog blog)
        {
            blog = blog ?? throw new ArgumentNullException(nameof(blog));
            blogRepository.Update(blog);
        }

        public void Delete(Blog blog)
        {
            blog = blog ?? throw new ArgumentNullException(nameof(blog));
            blogRepository.Delete(blog.Id);
        }

        public IEnumerable<Blog> GetLast10DaysBlogs()
        {

            return blogRepository.GetAll().Where(blog => blog.CreationDate.Date >= DateTime.Now.AddDays(-10).Date);

        }
        public IEnumerable<Blog> ReadAll() => blogRepository.GetAll();
        public Blog Read(string id)
        {
            id = id ?? throw new ArgumentNullException(nameof(id));
            return blogRepository.GetById(id);
        }

        public void CreateTag(Tag tag)
        {
            tag = tag ?? throw new ArgumentNullException(nameof(tag));
            tagRepository.Insert(tag);
        } 
        public void DeleteTag(Tag tag)
        {
            tag = tag ?? throw new ArgumentNullException(nameof(tag));
            tagRepository.Delete(tag.Id);
        }
        public IEnumerable<Tag> GetTags()
        {
            return tagRepository.GetAll();
        }
    }
}