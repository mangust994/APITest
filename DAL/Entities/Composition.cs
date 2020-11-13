using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Composition : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Mark { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public TimeSpan Duration { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<CompositionFranchise> CompositionFranchises { get; set; }
        public virtual List<CompositionGenre> CompositionGenres { get; set; }
        public Composition()
        {
            Comments = new List<Comment>();
            CompositionFranchises = new List<CompositionFranchise>();
            CompositionGenres = new List<CompositionGenre>();
        }
    }
}
