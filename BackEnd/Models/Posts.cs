using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models;

public class Posts
{
    public Guid id { get; set; }
    public Guid userId { get; set; }
    public string? description { get; set; }
    public string mediaUrl { get; set; }
    public string mediaType { get; set; }

    public Posts(string description, string mediaUrl, string mediatype)
    {
        this.description = description ?? throw new ArgumentNullException(nameof(description));
        this.mediaUrl = mediaUrl;
        this.mediaType = mediatype;
    }

}
