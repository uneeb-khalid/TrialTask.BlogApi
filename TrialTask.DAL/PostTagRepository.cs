using LiteDB;
using TrialTask.DataContracts;

namespace TrialTask.DAL
{
    internal class PostTagRepository : IPostTagRepository
    {
        private string _connectionString = "prodDb.db";
        public PostTagRepository(DbConfig dbConfig)
        {
            _connectionString = dbConfig.Database;
        }
        public IEnumerable<PostTag> GetAll(string postId)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<PostTag>("PostTags");
                return col.Find(pt => pt.PostId == postId).ToList();
            }

        }
        public Tag GetById(string id)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<Tag>("PostTags");
                return col.FindOne(b => b.Id == id);
            }
        }
        public void Insert(PostTag postTag)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<PostTag>("PostTags");
                col.Insert(postTag);
                //col.EnsureIndex<Blog>(b => b.Id);
            }
        }
        public void Update(PostTag tag)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<PostTag>("PostTags");
                col.Update(tag);
            }
        }
        public void Delete(string id)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<PostTag>("PostTags");
                col.Delete(id);
            }
        }
    }
}