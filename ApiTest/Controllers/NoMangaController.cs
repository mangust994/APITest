using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ApiTest.Controllers
{
    public class NoMangaController : ApiController
    {

        private readonly ICompositionService compositionService;

        public NoMangaController(ICompositionService compositionService)
        {
            this.compositionService = compositionService;
        }

        [HttpGet]
        public IEnumerable<NoMangaModel> GetNoManga()
        {
            return this.compositionService.GetNoManga();
        }

        public NoMangaModel GetNoManga(int id)
        {
            return this.compositionService.GetNoMangaById(id);
        }

        [HttpPost]
        public void PostNoManga([FromBody] NoMangaModel model)
        {
            compositionService.CreateNoManga(model);
        }

        public void PutNoManga(int id, [FromBody] NoMangaModel model)
        {
            compositionService.UpdateNoManga(id, model);
        }

        public void DeleteNoManga(int id)
        {
            compositionService.RemoveNoManga(id);
        }
    }
}