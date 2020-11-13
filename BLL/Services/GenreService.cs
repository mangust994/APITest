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
    class GenreService : IGenreService
    {
        private readonly IRepository repository;

        public GenreService(IRepository repo)
        {
            this.repository = repo;
        }
        public void CreateGenre(GenreModel model)
        {
            var mapper = MapHelper.Mapping<GenreModel, Genre>();
            Genre genre = mapper.Map<Genre>(model);
            this.repository.AddAndSave<Genre>(genre);
        }
        public void Dispose()
        {
            this.repository.Dispose();
        }
        public IEnumerable<GenreModel> GetGenre()
        {
            var mapper = MapHelper.Mapping<Genre, GenreModel>();
            return mapper.Map<List<GenreModel>>(this.repository.GetAll<Genre>());
        }

        public GenreModel GetGenre(Func<Genre, bool> predicate)
        {
            var mapper = MapHelper.Mapping<GenreModel, Genre>();
            return mapper.Map<GenreModel>(this.repository.FirstorDefault(predicate));
        }

        public GenreModel GetGenreById(int id)
        {
            var mapper = MapHelper.Mapping<GenreModel, Genre>();
            return mapper.Map<GenreModel>(this.repository.FirstorDefault<Genre>(x => x.Id == id));
        }

        public void RemoveGenre(int id)
        {
            var genre = this.repository.FirstorDefault<Genre>(x => x.Id == id);
            if (genre == null)
                throw new NullReferenceException();
            this.repository.RemoveAndSave(genre);
        }

        public void UpdateGenre(int id, GenreModel model)
        {
            var genre = this.repository.FirstorDefault<Genre>(x => x.Id == id);
            if (genre == null)
                throw new NullReferenceException();
            var mapper = MapHelper.Mapping<Genre, GenreModel>();
            genre = mapper.Map<Genre>(model);
            this.repository.UpdateAndSave(genre);
        }
    }
}
