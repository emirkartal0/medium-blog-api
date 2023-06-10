using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace medium_blog_api.Data
{
	public class AppDbContext : DbContext
	{
		protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
		{
			Configuration = configuration;
		}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // connect to postgres with connection string from app settings
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Label> Labels { get; set; }
    }
}
