using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository repository;
        private readonly IClientManager clientManager;

        public CommentService(IRepository repo, IClientManager clientManager)
        {
            this.clientManager = clientManager;
            this.repository = repo;
        }
        public void CreateComment(CommentModel model)
        {
            Comment comment = new Comment();
            comment.Id = model.Id;
            comment.Date = DateTime.Now;
            comment.ComMark = model.ComMark;
            comment.Text = model.Text;
            comment.CompositionId = model.CompositionId;
            comment.Composition = this.repository.GetAll<Composition>().FirstOrDefault(x => x.Id == model.CompositionId);
            comment.UserId = model.UserId;
            comment.User = this.clientManager.GetClient().FirstOrDefault(x => x.Id == model.UserId);
            this.repository.AddAndSave<Comment>(comment);
        }

        public void Dispose()
        {
            this.repository.Dispose();
        }
        public IEnumerable<CommentModel> GetComment()
        {
            var listComment = this.repository.GetAll<Comment>();
            var listModel = new List<CommentModel>();
            var compMap = MapHelper.Mapping<Composition, CompositionModel>();
            var userMap = MapHelper.Mapping<ClientProfile, AnimeUserModel>();
            foreach (var item in listComment)
            {
                var commentModel = new CommentModel();
                commentModel.Id = item.Id;
                commentModel.Text = item.Text;
                commentModel.Date = item.Date;
                commentModel.ComMark = item.ComMark;
                commentModel.CompositionId = item.CompositionId;
                commentModel.Composition = compMap.Map<CompositionModel>(item.Composition);
                commentModel.UserId = item.UserId;
                commentModel.User = userMap.Map<AnimeUserModel>(this.clientManager.GetClient().FirstOrDefault(x => x.Id == item.UserId));
                listModel.Add(commentModel);
            }
            return listModel;
        }
            

        public CommentModel GetComment(Func<Comment, bool> predicate)
        {
            var mapper = MapHelper.Mapping<CommentModel, Comment>();
            return mapper.Map<CommentModel>(this.repository.FirstorDefault(predicate));
        }

        public CommentModel GetCommentById(int id)
        {
            var mapper = MapHelper.Mapping<CommentModel, Comment>();
            return mapper.Map<CommentModel>(this.repository.FirstorDefault<Comment>(x => x.Id == id));
        }

        public void RemoveComment(int id)
        {
            var comment = this.repository.FirstorDefault<Comment>(x => x.Id == id);
            if (comment == null)
                throw new NullReferenceException();
            this.repository.RemoveAndSave(comment);
        }

        public void UpdateComment(int id, CommentModel model)
        {
            var comment = this.repository.FirstorDefault<Comment>(x => x.Id == id);
            if (comment == null)
                throw new NullReferenceException();
            comment.Id = model.Id;
            comment.Date = DateTime.Now;
            comment.ComMark = model.ComMark;
            comment.Text = model.Text;
            comment.CompositionId = model.CompositionId;
            comment.Composition = this.repository.GetAll<Composition>().FirstOrDefault(x => x.Id == model.CompositionId);
            comment.UserId = model.UserId;
            comment.User = this.clientManager.GetClient().FirstOrDefault(x => x.Id == model.UserId);
            this.repository.UpdateAndSave(comment);
        }
    }
}
