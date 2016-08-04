using Coursework.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Entity.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();

        User GetUser(string id);

        User Buy(int count, string id);
    }
}
