using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICompositionService : IDisposable
    {
        IEnumerable<AnimeModel> GetAnime();
        IEnumerable<NoMangaModel> GetNoManga();

        AnimeModel GetAnimeById(int id);
        NoMangaModel GetNoMangaById(int id);

        AnimeModel GetAnime(Func<Anime, bool> predicate);
        NoMangaModel GetNoManga(Func<NoManga, bool> predicate);

        void CreateAnime(AnimeModel model);
        void CreateNoManga(NoMangaModel model);

        void UpdateAnime(int id, AnimeModel model);
        void UpdateNoManga(int id, NoMangaModel model);

        void RemoveAnime(int id);
        void RemoveNoManga(int id);
    }
}
