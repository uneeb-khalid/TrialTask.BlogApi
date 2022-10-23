using LiteDB;
using TrialTask.DataContracts;

namespace TrialTask.DAL
{
    internal class UserRepository : IUserRepository
    {
        private string _connectionString = "prodDb.db";
        public UserRepository(DbConfig dbConfig)
        {
            _connectionString = dbConfig.Database;
        }
        public IEnumerable<User> GetAll()
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<User>("Users");
                return col.FindAll().ToList();
            }

        }
        public User FindById(string id)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<User>("Users");
                return col.FindOne(b => b.Id == id);
            }
        }
        public User FindByEmail(string email)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<User>("Users");
                return col.FindOne(b => b.Email == email);
            }
        }
        public void Insert(User user)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<User>("Users");
                col.Insert(user);
                //col.EnsureIndex<Blog>(b => b.Id);
            }
        }
        public void Update(User user)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<User>("Users");
                col.Update(user);
            }
        }
        public void Delete(string id)
        {
            using (var db = new LiteDatabase(_connectionString))
            {
                var col = db.GetCollection<User>("Users");
                col.Delete(id);
            }
        }
    }
}