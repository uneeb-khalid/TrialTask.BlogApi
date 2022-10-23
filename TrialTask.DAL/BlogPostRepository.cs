using LiteDB;
using TrialTask.DataContracts;

namespace TrialTask.DAL
{
    internal class BlogPostRepository : IBlogPostRepository
    {
        private string _connectionString = "prodDb.db";
        public BlogPostRepository(DbConfig dbConfig)
        {
            _connectionString = dbConfig.Database;
        }
        public IEnumerable<BlogPost> GetAll(string blogId)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<BlogPost>("BlogPosts");
                return col.Find(p => p.BlogId == blogId).ToList();
            }

        }
        public BlogPost GetById(string id)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<BlogPost>("BlogPosts");
                return col.FindOne(b => b.Id == id);
            }
        }
        public void Insert(BlogPost blog)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<BlogPost>("BlogPosts");
                col.Insert(blog);
                //col.EnsureIndex<Blog>(b => b.Id);
            }
        }
        public void Update(BlogPost blogPost)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<BlogPost>("BlogPosts");
                col.Update(blogPost);
            }
        }
        public void Delete(string id)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<BlogPost>("BlogPosts");
                col.Delete(id);
            }
        }
    }
}