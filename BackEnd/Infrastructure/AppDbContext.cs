using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<Like> Likes => Set<Like>();
    public DbSet<Friendship> Friendships => Set<Friendship>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

}
