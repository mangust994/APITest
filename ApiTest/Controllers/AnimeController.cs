using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ApiTest.Controllers
{
    public class AnimeController : ApiController
    {

        private readonly ICompositionService compositionService;

        public AnimeController(ICompositionService compositionService)
        {
            this.compositionService = compositionService;
        }
        [HttpGet]
        public IEnumerable<AnimeModel> GetAnime()
        {
            return this.compositionService.GetAnime();
        }

        public AnimeModel GetAnime(int id)
        {
            return this.compositionService.GetAnimeById(id);
        }

        [HttpPost]
        public void PostAnime([FromBody] AnimeModel model)
        {
            compositionService.CreateAnime(model);
        }

        public void PutAnime(int id, [FromBody] AnimeModel model)
        {
            compositionService.UpdateAnime(id, model);
        }

        public void DeleteAnime(int id)
        {
            compositionService.RemoveAnime(id);
        }
    }
}