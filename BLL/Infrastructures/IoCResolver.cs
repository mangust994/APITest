using BLL.Identity;
using BLL.Interfaces;
using BLL.Services;
using DAL;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositorys;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructures
{
    public class IoCResolver
    {
        public static void Load(Container container)
        {
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.Register<UserContext>(Lifestyle.Scoped);

            container.Register<IRepository, Repository>(Lifestyle.Scoped);

            container.Register<ICommentService, CommentService>(Lifestyle.Scoped);
            container.Register<ICompositionService, CompositionService>(Lifestyle.Scoped);
            container.Register<IFranchiseService, FranchiseService>(Lifestyle.Scoped);
            container.Register<IGenreService, GenreService>(Lifestyle.Scoped);
            container.Register<ICompositionFranchiseService, CompositionFranchiseService>(Lifestyle.Scoped);
            container.Register<ICompositionGenreService, CompositionGenreService>(Lifestyle.Scoped);
            container.Register<IClientManager, ClientManager>(Lifestyle.Scoped);
            container.Register<IUserService, UserService>(Lifestyle.Scoped);


            container.Register<IUserStore<AnimeUser>>(() => new UserStore<AnimeUser>(container.GetInstance<UserContext>()), Lifestyle.Scoped);
            container.Register<RoleStore<AnimeRole>>(() => new RoleStore<AnimeRole>(container.GetInstance<UserContext>()), Lifestyle.Scoped);


            container.Register<UserManager>(Lifestyle.Scoped);
            container.Register<RoleManager>(Lifestyle.Scoped);

        }
    }
}
