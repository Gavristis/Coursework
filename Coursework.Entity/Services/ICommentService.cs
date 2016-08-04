using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coursework.Entity.Entities;

namespace Coursework.Entity.Services
{
    public interface ICommentService
    {
        IEnumerable<Comment> GetAllComments();

        IEnumerable<Comment> GetComments(long eventId);

        void CreateComment(string userId, long eventId, string text);
    }
}
