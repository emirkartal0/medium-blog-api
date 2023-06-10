using System;

#region Default Convention
public class Label
{
	public int Id { get; set; }

	public string? Name { get; set; }

	public ICollection<Article>? Articles { get; set; }
}
#endregion

