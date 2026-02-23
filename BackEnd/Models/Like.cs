namespace BackEnd.Models;

public class Like
{
    public Guid id { get; set; }

    public Guid userId { get; set; }
    public User user { get; set; } = null!;

    public Guid postId { get; set; }
    public Post post { get; set; } = null!;

    public DateTime createdAt { get; set; } = DateTime.UtcNow;
}
