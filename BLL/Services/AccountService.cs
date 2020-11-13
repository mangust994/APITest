using BLL.Identity;
using BLL.Infrastructures;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository repository;

        private readonly UserManager userManager;

        public AccountService(IRepository repo, UserManager userManager)
        {
            this.repository = repo;
            this.userManager = userManager;
        }

        public async Task<ClaimsIdentity> AuthenticateAsync(string login, string password)
        {
            ClaimsIdentity claim = null;
            AnimeUser user = this.userManager.Find(login, password);

            if (user != null)
                claim = await this.userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        public void Dispose()
        {
            this.repository.Dispose();
        }

        public AnimeUser GetInfo(string id) =>
            this.userManager.FindById(id);


        public async Task<OperationDetails> RegisterAsync(string login, string password, string email, string name)
        {
            AnimeUser user = await this.userManager.FindByEmailAsync(email);
            if (user != null)
            {
                return new OperationDetails(false, "EmailAlreadyExist");
            }
            user = new AnimeUser
            {
                Email = email,
                UserName = login
            };

            var result = await this.userManager.CreateAsync(user, password);
            if (result.Errors.Count() > 0)
                return new OperationDetails(false, "InvalidRegistration");
            return new OperationDetails(true, "SuccessfulRegistration");
        }
    }
}
