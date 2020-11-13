using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ApiTest.Controllers
{
    public class GenreController : ApiController
    {

        private readonly IGenreService genreService;

        public GenreController(IGenreService genreService)
        {
            this.genreService = genreService;
        }

        [HttpGet]
        public IEnumerable<GenreModel> Get()
        {
            return this.genreService.GetGenre();
        }

        public GenreModel Get(int id)
        {
            return this.genreService.GetGenreById(id);
        }

        [HttpPost]
        public void Post([FromBody] GenreModel model)
        {
            genreService.CreateGenre(model);
        }

        public void Put(int id, [FromBody] GenreModel model)
        {
            genreService.UpdateGenre(id, model);
        }

        public void Delete(int id)
        {
            genreService.RemoveGenre(id);
        }
    }
}