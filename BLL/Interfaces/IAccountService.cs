﻿using BLL.Infrastructures;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAccountService : IDisposable
    {
        Task<ClaimsIdentity> AuthenticateAsync(string login, string password);

        Task<OperationDetails> RegisterAsync(string login, string password, string email, string name);

        AnimeUser GetInfo(string id);

    }
}
