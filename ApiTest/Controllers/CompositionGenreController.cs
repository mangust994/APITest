using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ApiTest.Controllers
{
    public class CompositionGenreController : ApiController
    {

        private readonly ICompositionGenreService compositionGenreService;

        public CompositionGenreController(ICompositionGenreService compositionGenreService)
        {
            this.compositionGenreService = compositionGenreService;
        }

        [HttpGet]
        public IEnumerable<CompositionGenreModel> Get()
        {
            return this.compositionGenreService.GetCompositionGenre();
        }
     
        public CompositionGenreModel Get(int id)
        {
            return this.compositionGenreService.GetCompositionGenreById(id);
        }

        [HttpPost]
        public void Post([FromBody] CompositionGenreModel model)
        {
            compositionGenreService.CreateCompositionGenre(model);
        }

        public void Put(int id, [FromBody] CompositionGenreModel model)
        {
            compositionGenreService.UpdateCompositionGenre(id, model);
        }

        public void Delete(int id)
        {
            compositionGenreService.RemoveCompositionGenre(id);
        }
    }
}