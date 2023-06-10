using System;
namespace medium_blog_api;

#region Default Convention
public class User
{
    public User()
    {
        Articles = new List<Article>();
    }

    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? UserPicture { get; set; }

    public ICollection<Article>? Articles { get; set; }
}
#endregion


