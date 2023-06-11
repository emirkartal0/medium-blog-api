using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using medium_blog_api.Data;
using medium_blog_api.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace medium_blog_api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : Controller
    {
        private readonly AppDbContext context;
        public ArticleController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpPost("postArticle")]
        [Authorize]
        public ActionResult PostArticle(AddArticleDTO article)
        {
            var userId = int.Parse(User.FindFirst("id")?.Value);

            var user = context.Users.Include(u => u.Articles).FirstOrDefault(u => u.Id == userId);
            user.Articles.Add(new Article()
            {
                ImageUrl = article.ImageUrl,
                Title = article.Title,
                Clap = article.Clap,
                Content = article.Content,
                CreatedDate = DateTime.UtcNow,
                Labels = article.LabelIds.Select(id => new Label() { Id = id }).ToList()
                // auto saved user by entity framework
            });

            context.SaveChanges();
            return Ok();
        }

        [HttpGet("getArticles")]
        public ActionResult GetAll()
        {
            var atricles = context.Articles.Include(a => a.Users);
            return Ok(atricles);
        }
    }
}

