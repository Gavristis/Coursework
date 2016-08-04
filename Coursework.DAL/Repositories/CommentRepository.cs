using Coursework.Entity.Entities;
using Coursework.Entity.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.DAL.Repositories
{
    class CommentRepository : ICommentRepository
    {
        private readonly MyDbContext _db;

        public CommentRepository(MyDbContext db)
        {
            _db = db;
        }

        public void Add(Comment item)
        {
            _db.Comments.Add(item);
        }

        public void Update(Comment item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(Comment item)
        {
            _db.Comments.Remove(item);
        }

        public void Delete(long id)
        {
            var com = Get(id);
            Delete(com);
        }

        public IEnumerable<Comment> Get()
        {
            return _db.Comments;
        }

        public Comment Get(long id)
        {
            return _db.Comments.Find(id);
        }

        public IEnumerable<Comment> Get(Func<Comment, bool> predicat)
        {
            return _db.Comments.Where(predicat);
        }
    }
}
