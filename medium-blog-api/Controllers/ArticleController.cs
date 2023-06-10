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
    public class ArticleController : Controller
    {
        private readonly AppDbContext context;
        public ArticleController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpPost("postArticle")]
        public ActionResult PostArticle(AddArticleDTO article)
        {
            context.Articles.Add(new Article()
            {
                ImageUrl = article.ImageUrl,
                Title = article.Title,
                Clap = article.Clap,
                Content = article.Content,
                CreatedDate = DateTime.Now,
                //Users = article.Users,
                //Labels = article.Labels
            });
            context.SaveChanges();
            return Ok();
        }
    }
}

