using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICommentService : IDisposable
    {
        IEnumerable<CommentModel> GetComment();

        CommentModel GetCommentById(int id);

        CommentModel GetComment(Func<Comment, bool> predicate);

        void CreateComment(CommentModel model);

        void UpdateComment(int id, CommentModel model);

        void RemoveComment(int id);
    }
}
