using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Franchise : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public virtual List<CompositionFranchise> CompositionFranchises { get; set; }
        public Franchise()
        {
            CompositionFranchises = new List<CompositionFranchise>();
        }
    }
}
