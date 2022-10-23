using LiteDB;
using TrialTask.DataContracts;
using System.Reflection.Metadata;

namespace TrialTask.DAL
{
    internal class BlogRepository : IBlogRepository
    {
        private string _connectionString = "prodDb.db";
        public BlogRepository(DbConfig dbConfig)
        {
            _connectionString = dbConfig.Database;
        }
        public IEnumerable<Blog> GetAll()
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<Blog>("Blogs");
                return col.FindAll().ToList();
            }

        }
        public Blog GetById(string id)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<Blog>("Blogs");
                return col.FindOne(b => b.Id == id);
            }
        }
        public void Insert(Blog blog)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<Blog>("Blogs");
                col.Insert(blog);
                //col.EnsureIndex<Blog>(b => b.Id);
            }
        }
        public void Update(Blog blog)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<Blog>("Blogs");
                col.Update(blog);
            }
        }
        public void Delete(string id)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<Blog>("Blogs");
                col.Delete(id);
            }
        }
    }
}