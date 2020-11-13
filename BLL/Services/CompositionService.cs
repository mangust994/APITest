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
    public class CompositionService : ICompositionService
    {
        private readonly IRepository repository;

        public CompositionService(IRepository repo)
        {
            this.repository = repo;
        }
        public void CreateAnime(AnimeModel model)
        {
            var mapper = MapHelper.Mapping<AnimeModel, Anime>();
            Anime anime = mapper.Map<Anime>(model);

            this.repository.AddAndSave<Anime>(anime);
        }

        public void CreateNoManga(NoMangaModel model)
        {
            var mapper = MapHelper.Mapping<NoMangaModel, NoManga>();
            NoManga noManga = mapper.Map<NoManga>(model);

            this.repository.AddAndSave<NoManga>(noManga);
        }

        public void Dispose()
        {
            this.repository.Dispose();
        }

        public IEnumerable<AnimeModel> GetAnime()
        {
            var mapper = MapHelper.Mapping<Anime, AnimeModel>();
            return mapper.Map<List<AnimeModel>>(this.repository.GetAll<Anime>());
        }

        public AnimeModel GetAnime(Func<Anime, bool> predicate)
        {
            var mapper = MapHelper.Mapping<AnimeModel, Anime>();
            return mapper.Map<AnimeModel>(this.repository.FirstorDefault(predicate));
        }

        public AnimeModel GetAnimeById(int id)
        {
            var mapper = MapHelper.Mapping<AnimeModel, Anime>();
            return mapper.Map<AnimeModel>(this.repository.FirstorDefault<Anime>(x => x.Id == id));
        }

        public IEnumerable<NoMangaModel> GetNoManga()
        {
            var mapper = MapHelper.Mapping<NoManga, NoMangaModel>();
            return mapper.Map<List<NoMangaModel>>(this.repository.GetAll<NoManga>());
        }

        public NoMangaModel GetNoManga(Func<NoManga, bool> predicate)
        {
            var mapper = MapHelper.Mapping<NoMangaModel, NoManga>();
            return mapper.Map<NoMangaModel>(this.repository.FirstorDefault(predicate));
        }

        public NoMangaModel GetNoMangaById(int id)
        {
            var mapper = MapHelper.Mapping<NoMangaModel, NoManga>();
            return mapper.Map<NoMangaModel>(this.repository.FirstorDefault<NoManga>(x => x.Id == id));
        }

        public void RemoveAnime(int id)
        {
            var anime = this.repository.FirstorDefault<Anime>(x => x.Id == id);
            if (anime == null)
                throw new NullReferenceException();
            this.repository.RemoveAndSave(anime);
        }

        public void RemoveNoManga(int id)
        {
            var noManga = this.repository.FirstorDefault<NoManga>(x => x.Id == id);
            if (noManga == null)
                throw new NullReferenceException();
            this.repository.RemoveAndSave(noManga);
        }

        public void UpdateAnime(int id, AnimeModel model)
        {
            var anime = this.repository.FirstorDefault<Anime>(x => x.Id == id);
            if (anime == null)
                throw new NullReferenceException();
            var mapper = MapHelper.Mapping<Anime, AnimeModel>();
            anime = mapper.Map<Anime>(model);

            this.repository.UpdateAndSave(anime);
        }

        public void UpdateNoManga(int id, NoMangaModel model)
        {
            var noManga = this.repository.FirstorDefault<NoManga>(x => x.Id == id);
            if (noManga == null)
                throw new NullReferenceException();
            var mapper = MapHelper.Mapping<NoManga, NoMangaModel>();
            noManga = mapper.Map<NoManga>(model);

            this.repository.UpdateAndSave(noManga);
        }
    }
}
