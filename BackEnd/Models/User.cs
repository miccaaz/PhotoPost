using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models;

public class User
{
    public Guid id { get; set; } 

    public string username { get; set; } = null!;
    public string passaword { get; set; } = null!;

    public string? bio { get; set; }
    public string? profileImageUrl { get; private set; }

    public DateTime createdAt { get; set; } = DateTime.UtcNow;
    public DateTime updateAt { get; set; } = DateTime.UtcNow;

    public ICollection<Post> Posts { get; set; } = new List<Post>();

    public User(string username, string passaword, string bio, string profileImageUrl)
    {
        this.username = username ?? throw new ArgumentNullException(nameof(username));
        this.passaword = passaword;
        this.bio = bio;
        this.profileImageUrl = profileImageUrl;
    }

}
