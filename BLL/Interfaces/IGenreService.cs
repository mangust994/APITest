using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGenreService : IDisposable
    {
        IEnumerable<GenreModel> GetGenre();

        GenreModel GetGenreById(int id);

        GenreModel GetGenre(Func<Genre, bool> predicate);

        void CreateGenre(GenreModel model);

        void UpdateGenre(int id, GenreModel model);

        void RemoveGenre(int id);

    }
}
