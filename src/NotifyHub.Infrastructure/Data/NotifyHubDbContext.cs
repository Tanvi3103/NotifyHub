using Microsoft.EntityFrameworkCore;
using NotifyHub.Domain.Entities;

namespace NotifyHub.Infrastructure.Data;

public class NotifyHubDbContext : DbContext
{
    public NotifyHubDbContext(DbContextOptions<NotifyHubDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Notification> Notifications => Set<Notification>();

    public DbSet<NotificationLog> NotificationLogs => Set<NotificationLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(NotifyHubDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}

