﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CompositionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Mark { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
