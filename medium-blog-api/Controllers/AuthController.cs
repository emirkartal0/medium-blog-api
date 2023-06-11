using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using medium_blog_api.Data;
using medium_blog_api.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


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
        public ActionResult UserLogin(UserLoginDTO dto)
        {

            var user = context.Users.FirstOrDefault(u => u.Email == dto.Email);
            if (user == null)
                return BadRequest();


            var expireTime = DateTime.Now.AddMinutes(60);
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("SUPERKEYYYSUPERKEYYYSUPERKEYYYSUPERKEYYYSUPERKEYYYSUPERKEYYYSUPERKEYYYSUPERKEYYY"));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var claims = new List<Claim>
            {
                new Claim("id", user.Id.ToString()),
                new Claim("email", user.Email.ToString())
            };

            var jwt = new JwtSecurityToken(
                                expires: expireTime,
                                notBefore: DateTime.Now,
                                claims: claims,
                                signingCredentials: signingCredentials
                        );
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return Ok(token);
        }

    }
}

