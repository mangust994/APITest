using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class NoMangaModel : CompositionModel
    {
        public int Volume { get; set; }
        public int Chapter { get; set; }
        public string Publisher { get; set; }
    }
}
