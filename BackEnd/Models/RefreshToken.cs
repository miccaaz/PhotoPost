namespace BackEnd.Models;

public class RefreshToken
{
    public Guid id { get; set; }

    public Guid userId { get; set; }
    public User user { get; set; } = null!;

    public string token { get; set; } = null!;

    public DateTime expiresAt { get; set; }
    public DateTime createdAt { get; set; } = DateTime.UtcNow;

    public bool revoked { get; set; } = false;
}
