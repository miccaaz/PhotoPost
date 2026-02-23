namespace BackEnd.Models;

public class Friendship
{
    public Guid id { get; set; }

    public Guid requesterId { get; set; }
    public User requester { get; set; } = null!;

    public Guid addresseeId { get; set; }
    public User addressee { get; set; } = null!;

    public string status { get; set; } = null!; // pending | accepted | rejected

    public DateTime createdAt { get; set; } = DateTime.UtcNow;
}
