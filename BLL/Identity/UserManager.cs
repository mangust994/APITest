using DAL.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Identity
{
    public class UserManager : UserManager<AnimeUser>
    {
        public UserManager(IUserStore<AnimeUser> store)
                : base(store)
        {
        }
    }
}
