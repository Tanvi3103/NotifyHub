using NotifyHub.Domain.Common;
using NotifyHub.Domain.Enums;

namespace NotifyHub.Domain.Entities;

public class Notification : BaseEntity
{
    public Guid UserId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;

    public NotificationChannel Channel { get; set; }

    public NotificationStatus Status { get; set; }

    public DateTime? ReadAt { get; set; }

    public User User { get; set; } = null!;
}