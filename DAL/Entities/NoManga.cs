using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class NoManga : Composition
    {
        public int Volume { get; set; }
        public int Chapter { get; set; }
        public string Publisher { get; set; }
    }
}
