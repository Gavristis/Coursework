using Coursework.Entity.Repositories;

namespace Coursework.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUserRepository _userRepository;

        private IPictureRepository _pictureRepository;

        private IFlowerRepository _flowerRepository;

        private ICommentRepository _commentRepository;

        private readonly MyDbContext _db;

        public UnitOfWork()
        {
            _db = MyDbContext.Create();
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_db)); }
        }

        public IPictureRepository PictureRepository
        {
            get { return _pictureRepository ?? (_pictureRepository = new PictureRepository(_db)); }
        }

        public IFlowerRepository FlowerRepository
        {
            get { return _flowerRepository ?? (_flowerRepository= new FlowerRepository(_db)); }
        }

        public ICommentRepository CommentRepository
        {
            get { return _commentRepository ?? (_commentRepository = new CommentRepository(_db)); }
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
