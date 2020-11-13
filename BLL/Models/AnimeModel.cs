using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class AnimeModel : CompositionModel
    {
        public int Episodes { get; set; }
        public string Studio { get; set; }
    }
}
