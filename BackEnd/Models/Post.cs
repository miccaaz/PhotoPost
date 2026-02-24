using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models;

public class Post
{
    public Guid id { get; set; }

    public Guid userId { get; set; }

    public string? description { get; set; }
    public string mediaUrl { get; set; }
    public string mediaType { get; set; }

    public DateTime createdAt { get; set; } = DateTime.UtcNow;
    public DateTime updatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Comment> comments { get; set; } = new List<Comment>();
    public ICollection<Like> likes { get; set; } = new List<Like>();

    public Post(string description, string mediaUrl, string mediatype)
    {
        this.description = description;
        this.mediaUrl = mediaUrl;
        this.mediaType = mediatype;
    }

}
