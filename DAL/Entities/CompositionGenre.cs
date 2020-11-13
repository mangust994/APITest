using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class CompositionGenre : IEntity
    {
        public int Id { get; set; }
        public int? CompositionId { get; set; }
        public virtual Composition Composition { get; set; }
        public int? GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
