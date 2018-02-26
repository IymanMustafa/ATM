using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Service;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly ILoginService loginService;

        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }
        [HttpGet("{id}")]
        public Account Get(int id)
        {
            if(id == 1234)
            {
                return new Account
                {
                    Balance = 10,
                    ExpirationDate = DateTime.Now,
                    Name = "Tom Jefferson",
                    Number = "1234"
                };
            }
            return null;
        }

        // POST api/values
        [HttpPost]
        public bool Post([FromBody] LoginModel value)
        {
           return loginService.IsValidLogin(value.CCNumber, value.Pin);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
