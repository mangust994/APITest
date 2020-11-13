using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICompositionGenreService : IDisposable
    {
        IEnumerable<CompositionGenreModel> GetCompositionGenre();

        CompositionGenreModel GetCompositionGenreById(int id);

        CompositionGenreModel GetCompositionGenre(Func<CompositionGenre, bool> predicate);

        void CreateCompositionGenre(CompositionGenreModel model);

        void UpdateCompositionGenre(int id, CompositionGenreModel model);

        void RemoveCompositionGenre(int id);
    }
}
