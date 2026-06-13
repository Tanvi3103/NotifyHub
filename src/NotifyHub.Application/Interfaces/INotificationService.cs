using NotifyHub.Application.DTOs;

namespace NotifyHub.Application.Interfaces;

public interface INotificationService
{
    Task<Guid> CreateNotificationAsync(CreateNotificationRequest request);

    Task<List<NotificationResponse>> GetNotificationsByUserIdAsync(Guid userId);

    Task MarkAsReadAsync(Guid notificationId);
}