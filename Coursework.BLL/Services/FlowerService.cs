using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coursework.Entity.Entities;
using Coursework.Entity.Services;
using Coursework.Entity.Repositories;

namespace Coursework.BLL.Services
{
    public class FlowerService : IFlowerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FlowerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Flower> GetAllFlowers()
        {
            return _unitOfWork.FlowerRepository.Get().ToList();
        }

        public void CreateFlower(string userId, string name)
        {
            var account = _unitOfWork.UserRepository.Get(userId);
            if (account.Purchased > 0)
            {
                var _flower = new Flower
                {
                    UserId = userId,
                    User = account,
                    FlowerName = name
                };
                _unitOfWork.FlowerRepository.Add(_flower);
                account.Purchased--;
            }
            else
            {
                throw new ValidationException("You have no purchased flowers");
            }
            _unitOfWork.Save();
        }

        public Flower GetFlower(long id)
        {
            return _unitOfWork.FlowerRepository.Get(id);
        }

        public void DeleteFlower(long id)
        {
            _unitOfWork.FlowerRepository.Delete(id);
            _unitOfWork.Save();
        }
    }
}
