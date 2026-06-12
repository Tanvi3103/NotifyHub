using NotifyHub.Domain.Common;
using NotifyHub.Domain.Enums;

namespace NotifyHub.Domain.Entities;

public class NotificationLog : BaseEntity
{
    public Guid NotificationId { get; set; }

    public int RetryCount { get; set; }

    public DeliveryStatus DeliveryStatus { get; set; }

    public Notification Notification { get; set; } = null!;
}