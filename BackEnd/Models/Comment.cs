namespace BackEnd.Models;

public class Comment
{
    public Guid id { get; set; }

    public Guid postId { get; set; }
    public Post post { get; set; } = null!;

    public Guid userId { get; set; }
    public User user { get; set; } = null!;

    public string content { get; set; } = null!;

    public DateTime createdAt { get; set; } = DateTime.UtcNow;
    public DateTime updatedAt { get; set; } = DateTime.UtcNow;
}
