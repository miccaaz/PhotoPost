using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models;

public class User
{
    public Guid id { get; set; } 

    public string username { get; set; } = null!;
    public string passwordHash { get; set; } = null!;

    public string? bio { get; set; }
    public string? profileImageUrl { get; private set; }

    public DateTime createdAt { get; set; } = DateTime.UtcNow;
    public DateTime updatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Post> posts { get; set; } = new List<Post>();
    public ICollection<Comment> comments { get; set; } = new List<Comment>();
    public ICollection<Like> likes { get; set; } = new List<Like>();

    public User(string username, string passwordHash, string bio, string profileImageUrl)
    {
        this.username = username ?? throw new ArgumentNullException(nameof(username));
        this.passwordHash = passwordHash;
        this.bio = bio;
        this.profileImageUrl = profileImageUrl;
    }

}
