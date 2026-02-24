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

    [Obsolete]
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        // USER
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.HasKey(u => u.id);

            entity.Property(u => u.id)
                  .HasColumnType("uuid")
                  .HasDefaultValueSql("gen_random_uuid()");

            entity.Property(u => u.username)
                  .HasMaxLength(50)
                  .IsRequired();

            entity.HasIndex(u => u.username).IsUnique();

            entity.Property(u => u.passwordHash)
                  .HasColumnType("text")
                  .IsRequired();

            entity.Property(u => u.bio)
                  .HasColumnType("text");

            entity.Property(u => u.profileImageUrl)
                  .HasColumnType("text");

            entity.Property(u => u.createdAt)
                  .HasColumnType("timestamp with time zone")
                  .HasDefaultValueSql("NOW()");

            entity.Property(u => u.updatedAt)
                  .HasColumnType("timestamp with time zone")
                  .HasDefaultValueSql("NOW()");
        });

        // POST
        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("posts");

            entity.HasKey(p => p.id);

            entity.Property(p => p.id)
                  .HasColumnType("uuid")
                  .HasDefaultValueSql("gen_random_uuid()");

            entity.Property(p => p.description)
                  .HasColumnType("text");

            entity.Property(p => p.mediaUrl)
                  .HasColumnType("text")
                  .IsRequired();

            entity.Property(p => p.mediaType)
                  .HasColumnType("varchar(10)")
                  .IsRequired();

            entity.Property(p => p.createdAt)
                  .HasColumnType("timestamp with time zone")
                  .HasDefaultValueSql("NOW()");

            entity.Property(p => p.updatedAt)
                  .HasColumnType("timestamp with time zone")
                  .HasDefaultValueSql("NOW()");

            entity.HasCheckConstraint("ck_posts_media_type",
                "media_type IN ('image', 'video')");

            entity.HasOne(p => p.user)
                  .WithMany(u => u.Posts)
                  .HasForeignKey(p => p.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // COMMENT
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("comments");

            entity.HasKey(c => c.id);

            entity.Property(c => c.id)
                  .HasColumnType("uuid")
                  .HasDefaultValueSql("gen_random_uuid()");

            entity.Property(c => c.content)
                  .HasColumnType("text")
                  .IsRequired();

            entity.Property(c => c.createdAt)
                  .HasColumnType("timestamp with time zone")
                  .HasDefaultValueSql("NOW()");

            entity.Property(c => c.updatedAt)
                  .HasColumnType("timestamp with time zone")
                  .HasDefaultValueSql("NOW()");

            entity.HasOne(c => c.post)
                  .WithMany(p => p.comments)
                  .HasForeignKey(c => c.postId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(c => c.user)
                  .WithMany(u => u.comments)
                  .HasForeignKey(c => c.userId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // LIKE
        modelBuilder.Entity<Like>(entity =>
        {
            entity.ToTable("likes");

            entity.HasKey(l => l.id);

            entity.Property(l => l.id)
                  .HasColumnType("uuid")
                  .HasDefaultValueSql("gen_random_uuid()");

            entity.Property(l => l.createdAt)
                  .HasColumnType("timestamp with time zone")
                  .HasDefaultValueSql("NOW()");

            entity.HasIndex(l => new { l.userId, l.postId })
                  .IsUnique();

            entity.HasOne(l => l.user)
                  .WithMany(u => u.likes)
                  .HasForeignKey(l => l.userId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(l => l.post)
                  .WithMany(p => p.likes)
                  .HasForeignKey(l => l.postId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // FRIENDSHIP
        modelBuilder.Entity<Friendship>(entity =>
        {
            entity.ToTable("friendships");

            entity.HasKey(f => f.id);

            entity.Property(f => f.id)
                  .HasColumnType("uuid")
                  .HasDefaultValueSql("gen_random_uuid()");

            entity.Property(f => f.status)
                  .HasColumnType("varchar(20)")
                  .IsRequired();

            entity.Property(f => f.createdAt)
                  .HasColumnType("timestamp with time zone")
                  .HasDefaultValueSql("NOW()");

            entity.HasCheckConstraint("ck_friendships_status",
                "status IN ('pending', 'accepted', 'rejected')");

            entity.HasOne(f => f.requester)
                  .WithMany()
                  .HasForeignKey(f => f.requesterId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(f => f.addressee)
                  .WithMany()
                  .HasForeignKey(f => f.addresseeId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // REFRESH TOKEN
        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.ToTable("refresh_tokens");

            entity.HasKey(r => r.id);

            entity.Property(r => r.id)
                  .HasColumnType("uuid")
                  .HasDefaultValueSql("gen_random_uuid()");

            entity.Property(r => r.token)
                  .HasColumnType("text")
                  .IsRequired();

            entity.Property(r => r.expiresAt)
                  .HasColumnType("timestamp with time zone")
                  .IsRequired();

            entity.Property(r => r.createdAt)
                  .HasColumnType("timestamp with time zone")
                  .HasDefaultValueSql("NOW()");

            entity.Property(r => r.revoked)
                  .HasColumnType("boolean")
                  .HasDefaultValue(false);

            entity.HasOne(r => r.user)
                  .WithMany()
                  .HasForeignKey(r => r.userId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
