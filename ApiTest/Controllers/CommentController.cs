using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ApiTest.Controllers
{
    public class CommentController : ApiController
    {

        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpGet]
        public IEnumerable<CommentModel> Get()
        {
            return this.commentService.GetComment();
        }

        public CommentModel Get(int id)
        {
            return this.commentService.GetCommentById(id);
        }

        [HttpPost]
        public void Post([FromBody] CommentModel model)
        {
            commentService.CreateComment(model);
        }

        public void Put(int id, [FromBody] CommentModel model)
        {
            commentService.UpdateComment(id, model);
        }

        public void Delete(int id)
        {
            commentService.RemoveComment(id);
        }
    }
}