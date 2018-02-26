using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Service;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        [HttpPost,AllowAnonymous]
        public Profile Login([FromBody] LoginAccount loginAccount)
        {
           return accountService.Login(loginAccount.Username, loginAccount.Password);
        }
        [HttpGet]
        public Account Get()
        {
           return accountService.Get(int.Parse(HttpContext.User.Claims.Where(c => c.Type == "UserId").Single().Value));
        }

        [HttpPost,Authorize]
        public bool Post([FromBody] RegisterAccountModel registerAccountModel) 
        {
            if (registerAccountModel == null) throw new ArgumentNullException(nameof(registerAccountModel));
            return accountService.Create(registerAccountModel);
        }
        [HttpDelete,Authorize]
        public void Delete()
        {
            accountService.Delete(int.Parse(HttpContext.User.Claims.Where(c => c.Type == "UserId").Single().Value));
        }
    }
}
