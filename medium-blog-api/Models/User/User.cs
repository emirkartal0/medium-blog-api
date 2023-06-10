using System;

#region Default Convention
public class User
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? UserPicture { get; set; }

    public ICollection<Article>? Articles { get; set; }
}
#endregion


