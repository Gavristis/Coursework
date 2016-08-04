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
    class PictureRepository : IPictureRepository
    {
        private readonly MyDbContext _db;

        public PictureRepository(MyDbContext db)
        {
            _db = db;
        }

        public void Add(Picture item)
        {
            _db.Pictures.Add(item);
        }

        public void Update(Picture item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(Picture item)
        {
            _db.Pictures.Remove(item);
        }

        public void Delete(long id)
        {
            var _picture = Get(id);
            Delete(_picture);
        }

        public IEnumerable<Picture> Get()
        {
            return _db.Pictures;
        }

        public Picture Get(long id)
        {
            return _db.Pictures.Find(id);
        }

        public IEnumerable<Picture> Get(Func<Picture, bool> predicat)
        {
            return _db.Pictures.Where(predicat);
        }
    }
}
