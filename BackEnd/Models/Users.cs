using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models;

public class Users
{
    public Guid id { get; set; } 
    public string username { get; set; } = null!;
    public string passaword { get; set; } = null!;
    public string? bio { get; set; }
    public string? profileImageUrl { get; private set; }
    public ICollection<Posts> Posts { get; set; } = new List<Posts>();

    public Users(string username, string passaword)
    {
        this.username = username ?? throw new ArgumentNullException(nameof(username));
        this.passaword = passaword;
    }

}
