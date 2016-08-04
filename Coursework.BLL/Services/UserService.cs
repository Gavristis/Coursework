using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coursework.Entity.Services;
using Coursework.Entity.Entities;
using Coursework.Entity.Repositories;

namespace Coursework.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _unitOfWork.UserRepository.Get().ToList();
        }


        public User GetUser(string id)
        {
            return _unitOfWork.UserRepository.Get(id);
        }

        public User Buy(int count, string id)
        {
            User u = _unitOfWork.UserRepository.Get(id);
            u.Purchased += count;
            _unitOfWork.UserRepository.Update(u);
            _unitOfWork.Save();
            return u;
        }
    }
}
