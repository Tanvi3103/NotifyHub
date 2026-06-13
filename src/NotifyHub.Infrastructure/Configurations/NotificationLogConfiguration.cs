using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotifyHub.Domain.Entities;

namespace NotifyHub.Infrastructure.Configurations;

public class NotificationLogConfiguration : IEntityTypeConfiguration<NotificationLog>
{
    public void Configure(EntityTypeBuilder<NotificationLog> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.RetryCount)
            .HasDefaultValue(0);

        builder.Property(x => x.DeliveryStatus)
            .IsRequired();

        builder.HasOne(x => x.Notification)
            .WithMany(x => x.NotificationLogs)
            .HasForeignKey(x => x.NotificationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}