using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using medium_blog_api.Data;
using medium_blog_api.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public ActionResult UserRegister(UserRegisterDTO  dto)
        {
            context.Users.Add(new medium_blog_api.User()
            {
                Email = dto.Email,
                Password = dto.Password,
                UserName = dto.UserName
            });
            context.SaveChanges();
            return Ok();
        }

    }
}

