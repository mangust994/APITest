using BLL.Identity;
using BLL.Infrastructures;
using BLL.Interfaces;
using BLL.Models;
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
    public class UserService : IUserService
    {
        private readonly UserManager userManager;

        private readonly RoleManager roleManager;

        private readonly IClientManager clientManager;

        private readonly IRepository repo;

        public UserService(IClientManager clientManager, IRepository repo, UserManager userManager, RoleManager roleManager)
        {
            this.clientManager = clientManager;
            this.repo = repo;
            this.userManager = userManager;
            this.roleManager = roleManager;

        }
        public async Task<OperationDetails> Create(AnimeUserModel userModel)
        {
            AnimeUser user = await userManager.FindByEmailAsync(userModel.Email);
            if (user == null)
            {
                user = new AnimeUser { Email = userModel.Email, UserName = userModel.Email };
                var result = await userManager.CreateAsync(user, userModel.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault());
                await userManager.AddToRoleAsync(user.Id, userModel.Role);
                ClientProfile clientProfile = new ClientProfile { Id = user.Id, Address = userModel.Address, Name = userModel.Name };
                clientManager.Create(clientProfile);
                await repo.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(AnimeUserModel userModel)
        {
            ClaimsIdentity claim = null;
            AnimeUser user = await userManager.FindAsync(userModel.Email, userModel.Password);
            if (user != null)
                claim = await userManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        public async Task SetInitialData(AnimeUserModel adminAnime, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await roleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new AnimeRole { Name = roleName };
                    await roleManager.CreateAsync(role);
                }
            }
            await Create(adminAnime);
        }

        public void Dispose()
        {
            repo.Dispose();
        }
    }
}
