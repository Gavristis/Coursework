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
    class FlowerRepository : IFlowerRepository
    {
        private readonly MyDbContext _db;

        public FlowerRepository(MyDbContext db)
        {
            _db = db;
        }

        public void Add(Flower item)
        {
            _db.Flowers.Add(item);
        }

        public void Update(Flower item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(Flower item)
        {
            _db.Flowers.Remove(item);
        }

        public void Delete(long id)
        {
            var _flower = Get(id);
            Delete(_flower);
        }

        public IEnumerable<Flower> Get()
        {
            return _db.Flowers;
        }

        public Flower Get(long id)
        {
            return _db.Flowers.Find(id);
        }

        public IEnumerable<Flower> Get(Func<Flower, bool> predicat)
        {
            return _db.Flowers.Where(predicat);
        }
    }
}
