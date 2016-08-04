using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coursework.Entity.Entities;
using Coursework.Entity.Repositories;

namespace Coursework.DAL.Repositories
{
    class UserRepository : IUserRepository
    {
        private readonly MyDbContext _db;

        public UserRepository(MyDbContext db)
        {
            _db = db;
        }

        public void Add(User item)
        {
            _db.Users.Add(item);
        }

        public void Update(User item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(User item)
        {
            _db.Users.Remove(item);
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Get()
        {
            return _db.Users;
        }

        public User Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Get(Func<User, bool> predicat)
        {
            return _db.Users.Where(predicat);
        }

        public User Get(string id)
        {
            return _db.Users.Find(id);
        }

        public void Delete(string id)
        {
            var user = Get(id);
            Delete(user);
        }
    }
}
