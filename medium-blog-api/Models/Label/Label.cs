using System;
using medium_blog_api;

#region Default Convention
public class Label
{
	public Label()
	{
		Articles = new List<Article>();
	}

	public int Id { get; set; }

	public string? Name { get; set; }

	public ICollection<Article>? Articles { get; set; }
}
#endregion
