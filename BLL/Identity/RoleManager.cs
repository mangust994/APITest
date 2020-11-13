using DAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Identity
{
    public class RoleManager : RoleManager<AnimeRole>
    {
        public RoleManager(RoleStore<AnimeRole> store)
                    : base(store)
        { }
    }
}
