using LiteDB;
using TrialTask.DataContracts;

namespace TrialTask.DAL
{
    internal class TagRepository : ITagRepository
    {
        private string _connectionString = "prodDb.db";
        public TagRepository(DbConfig dbConfig)
        {
            _connectionString = dbConfig.Database;
        }
        public IEnumerable<Tag> GetAll()
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<Tag>("Tags");
                return col.FindAll().ToList();
            }

        }
        public Tag GetById(string id)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<Tag>("Tags");
                return col.FindOne(b => b.Id == id);
            }
        }
        public void Insert(Tag tags)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<Tag>("Tags");
                col.Insert(tags);
                //col.EnsureIndex<Blog>(b => b.Id);
            }
        } 
        public void Update(Tag tag)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<Tag>("Tags");
                col.Update(tag);
            }
        }
        public void Delete(string id)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<Tag>("Tags");
                col.Delete(id);
            }
        }
    }
}