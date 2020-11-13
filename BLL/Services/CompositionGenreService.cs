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
    public class CompositionGenreService : ICompositionGenreService
    {
        private readonly IRepository repository;

        public CompositionGenreService(IRepository repo)
        {
            this.repository = repo;
        }
        public void CreateCompositionGenre(CompositionGenreModel model)
        {
            var composition = this.repository.FirstorDefault<Composition>(x => x.Id == model.Composition.Id);
            var Genre = this.repository.FirstorDefault<Genre>(x => x.Id == model.Genre.Id);
            CompositionGenre compositionGenre = new CompositionGenre();
            compositionGenre.CompositionId = composition.Id;
            compositionGenre.Composition = composition;
            compositionGenre.Genre = Genre;
            compositionGenre.GenreId = Genre.Id;
            this.repository.AddAndSave<CompositionGenre>(compositionGenre);
        }

        public void Dispose()
        {
            this.repository.Dispose();
        }
        public IEnumerable<CompositionGenreModel> GetCompositionGenre()
        {
            var listComposGenre = this.repository.GetAll<CompositionGenre>();
            var listmodel = new List<CompositionGenreModel>();
            var compMap = MapHelper.Mapping<Composition, CompositionModel>();
            var genreMap = MapHelper.Mapping<Genre, GenreModel>();
            foreach (var item in listComposGenre)
            {
                var model = new CompositionGenreModel();
                model.Id = item.Id;
                model.CompositionId = item.CompositionId;
                model.GenreId = item.GenreId;
                model.Composition = compMap.Map<CompositionModel>(item.Composition);
                model.Genre = genreMap.Map<GenreModel>(item.Genre);
                listmodel.Add(model);
            }
            return listmodel;
        }


        public CompositionGenreModel GetCompositionGenre(Func<CompositionGenre, bool> predicate)
        {
            var mapper = MapHelper.Mapping<CompositionGenreModel, CompositionGenre>();
            return mapper.Map<CompositionGenreModel>(this.repository.FirstorDefault(predicate));
        }

        public CompositionGenreModel GetCompositionGenreById(int id)
        {
            var entity = this.repository.FirstorDefault<CompositionGenre>(x => x.Id == id);
            var model = new CompositionGenreModel();
            model.Id = entity.Id;
            model.CompositionId = entity.CompositionId;
            model.GenreId = entity.GenreId;
            return model;
        }

        public void RemoveCompositionGenre(int id)
        {
            var compositionGenre = this.repository.FirstorDefault<CompositionGenre>(x => x.Id == id);
            if (compositionGenre == null)
                throw new NullReferenceException();
            this.repository.RemoveAndSave(compositionGenre);
        }

        public void UpdateCompositionGenre(int id, CompositionGenreModel model)
        {
            var compositionGenre = this.repository.FirstorDefault<CompositionGenre>(x => x.Id == id);
            if (compositionGenre == null)
                throw new NullReferenceException();
            var compositionMap = MapHelper.Mapping<CompositionModel, Composition>();
            var GenreMap = MapHelper.Mapping<GenreModel, Genre>();
            compositionGenre.CompositionId = model.CompositionId;
            compositionGenre.Composition = compositionMap.Map<Composition>(model.Composition);
            compositionGenre.Genre = GenreMap.Map<Genre>(model.Genre);
            compositionGenre.GenreId = model.GenreId;
            this.repository.UpdateAndSave(compositionGenre);
        }
    }
}
