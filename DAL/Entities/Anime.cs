using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Anime : Composition
    {
        public int Episodes { get; set; }
        public string Studio { get; set; }
    }
}
