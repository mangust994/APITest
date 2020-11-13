using BLL.Infrastructures;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(AnimeUserModel userModel);
        Task<ClaimsIdentity> Authenticate(AnimeUserModel userModel);
        Task SetInitialData(AnimeUserModel adminAnime, List<string> roles);
    }
}
