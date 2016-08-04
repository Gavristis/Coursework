using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coursework.Entity.Entities;
using Coursework.Entity.Repositories;
using Coursework.Entity.Services;

namespace Coursework.BLL.Services
{
    public class PictureService: IPictureService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PictureService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void CreatePicture(long flowerId, byte[] imageData)
        {
            var _picture = new Picture
            {
                FlowerId = flowerId,
                Image = imageData
            };
            _unitOfWork.PictureRepository.Add(_picture);
            _unitOfWork.Save();
        }

        public IEnumerable<Picture> GetAllPictures()
        {
            return _unitOfWork.PictureRepository.Get().ToList();
        }

        public Picture GetPicture(long id)
        {
            return _unitOfWork.PictureRepository.Get(id);
        }
    }
}
