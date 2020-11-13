using BLL.Infrastructures;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ApiTest.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private readonly IUserService UserService;
        public AccountController(IUserService UserService)
        {
            this.UserService = UserService;
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }

        [Route("Login")]
        public async Task<OperationDetails> Login(LoginModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                AnimeUserModel animeUserModel = new AnimeUserModel { Email = model.Email, Password = model.Password };
                ClaimsIdentity claim = await UserService.Authenticate(animeUserModel);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Wrong login or password.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return new OperationDetails(true, "You've been successfully logged in");
                }
            }
            return new OperationDetails(false, "Model state is not valid");
        }

        public OperationDetails Logout()
        {
            AuthenticationManager.SignOut();
            return new OperationDetails(true, "You have successfuly logged out");
        }

        [Route("Register")]
        public async Task<OperationDetails> Register(RegisterModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                AnimeUserModel animeUserModel = new AnimeUserModel
                {
                    Email = model.Email,
                    Password = model.Password,
                    Address = model.Address,
                    Name = model.Name,
                    Role = "user"
                };
                OperationDetails operationDetails = await UserService.Create(animeUserModel);
                if (operationDetails.Succedeed)
                    return new OperationDetails(true, "Successful Registration");
                else
                    ModelState.AddModelError(operationDetails.Message, operationDetails.Message);
            }
            return new OperationDetails(false, "Model state is not valid");
        }
        private async Task SetInitialDataAsync()
        {
            await UserService.SetInitialData(new AnimeUserModel
            {
                Email = "somemail@mail.ru",
                UserName = "somemail@mail.ru",
                Password = "ad46D_ewr3",
                Name = "Семен Семенович Tushe",
                Address = "ул. Спортивная, д.30, кв.75",
                Role = "admin",
            }, new List<string> { "user", "admin" });
        }
    }
}