using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using medium_blog_api.Data;
using medium_blog_api.Dto;
using Microsoft.AspNetCore.Mvc;


namespace medium_blog_api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly AppDbContext context;
        public AuthController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpPost("register")]
        public ActionResult UserRegister(UserRegisterDTO  user)
        {
            context.Users.Add(new User()
            {
                Email = user.Email,
                Password = user.Password,
                UserName = user.UserName
            });
            context.SaveChanges();
            return Ok();
        }

        [HttpPost("login")]
        public ActionResult UserLogin(UserLoginDTO user)
        {
            var myUser = context.Users.FirstOrDefault(u => u.Email == user.Email
                                                        && u.Password == user.Password);

            if (myUser != null)
            {
                myUser.Password = null;
                return Ok(myUser);
            }
            else
            {
                return NotFound();
            }
        }

    }
}

