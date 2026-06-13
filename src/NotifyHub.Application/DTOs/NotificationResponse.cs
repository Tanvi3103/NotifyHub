using NotifyHub.Domain.Enums;

namespace NotifyHub.Application.DTOs;

public class NotificationResponse
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;

    public NotificationStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }
}