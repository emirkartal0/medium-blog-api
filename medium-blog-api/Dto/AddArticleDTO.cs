using System;
namespace medium_blog_api.Dto
{
	public class AddArticleDTO
	{
        public string? ImageUrl { get; set; }

        public string? Title { get; set; }

        public int Clap { get; set; }

        public string? Content { get; set; }

        public List<int> LabelIds { get; set; }

    }
}

