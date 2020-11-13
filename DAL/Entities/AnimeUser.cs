﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class AnimeUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
        public virtual AnimeRole AnimeRole { get; set; }
    }
}
