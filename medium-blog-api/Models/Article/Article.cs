using System;

#region Default Convention
public class Article
{
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
