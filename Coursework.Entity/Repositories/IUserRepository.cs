using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coursework.Entity.Entities;

namespace Coursework.Entity.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User Get(string id);

        void Delete(string id);
    }
}
