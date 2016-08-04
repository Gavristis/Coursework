using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coursework.Entity.Entities;

namespace Coursework.Entity.Services
{
    public interface IPictureService
    {
        IEnumerable<Picture> GetAllPictures();

        void CreatePicture(long flowerId, byte[] imageData);

        Picture GetPicture(long id);
    }
}
