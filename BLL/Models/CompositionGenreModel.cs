using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CompositionGenreModel
    {
        public int Id { get; set; }
        public int? CompositionId { get; set; }
        public CompositionModel Composition { get; set; }
        public int? GenreId { get; set; }
        public GenreModel Genre { get; set; }
    }
}
