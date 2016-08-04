using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Entity.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        IPictureRepository PictureRepository { get; }

        IFlowerRepository FlowerRepository { get; }

        ICommentRepository CommentRepository { get; }

        void Save();
    }
}
