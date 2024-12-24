using DAL.Entities;
using Microsoft.EntityFrameworkCore;

public class ChatContext : DbContext
{
    public ChatContext(DbContextOptions<ChatContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Message> Messages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Message>()
            .HasOne(m => m.FromUser)
            .WithMany()
            .HasForeignKey(m => m.FromId)
            .OnDelete(DeleteBehavior.Restrict); // Заміна каскадного видалення

        modelBuilder.Entity<Message>()
            .HasOne(m => m.ToUser)
            .WithMany()
            .HasForeignKey(m => m.ToId)
            .OnDelete(DeleteBehavior.Restrict); // Заміна каскадного видалення
    }
}
