using LiteDB;
using TrialTask.DataContracts;

namespace TrialTask.DAL
{
    internal class CommentRepository : ICommentRepository
    {
        private string _connectionString = "prodDb.db";
        public CommentRepository(DbConfig dbConfig)
        {
            _connectionString = dbConfig.Database;
        }
        public IEnumerable<Comment> GetAll(string postId)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<Comment>("Comments");
                return col.Find(p => p.PostId == postId).ToList();
            }

        }
        public Comment GetById(string id)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<Comment>("Comments");
                return col.FindOne(b => b.Id == id);
            }
        }
        public void Insert(Comment comment)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<Comment>("Comments");
                col.Insert(comment);
                //col.EnsureIndex<Blog>(b => b.Id);
            }
        }
        public void Update(Comment comment)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<Comment>("Comments");
                col.Update(comment);
            }
        }
        public void Delete(string id)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<Comment>("Comments");
                col.Delete(id);
            }
        }
    }
}