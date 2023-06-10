using System;
namespace medium_blog_api;

#region Default Convention
public class Article
{

	public Article()
	{
		Users = new List<User>();
		Labels = new List<Label>();
	}

	public int Id { get; set; }

	public string? ImageUrl { get; set; }

	public string? Title { get; set; }

	public int Clap { get; set; }

	public string? Content { get; set; }

	public DateTime CreatedDate { get; set; }

	public ICollection<User>? Users { get; set; }

	public ICollection<Label>? Labels { get; set; }
}
#endregion
