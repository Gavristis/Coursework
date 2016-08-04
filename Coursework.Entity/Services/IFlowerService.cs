using Coursework.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Entity.Services
{
    public interface IFlowerService
    {
        IEnumerable<Flower> GetAllFlowers();

        void CreateFlower(string userId, string name);

        Flower GetFlower(long id);

        void DeleteFlower(long id);
    }
}
