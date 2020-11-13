using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CompositionFranchiseModel
    {
        public int Id { get; set; }
        public int? CompositionId { get; set; }
        public CompositionModel Composition { get; set; }
        public int? FranchiseId { get; set; }
        public FranchiseModel Franchise { get; set; }
    }
}
