using Microsoft.EntityFrameworkCore;
using NotifyHub.Application.DTOs;
using NotifyHub.Application.Interfaces;
using NotifyHub.Domain.Entities;
using NotifyHub.Domain.Enums;
using NotifyHub.Infrastructure.Data;

namespace NotifyHub.Infrastructure.Services;

public class NotificationService : INotificationService
{
    private readonly NotifyHubDbContext _context;

    public NotificationService(NotifyHubDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateNotificationAsync(
        CreateNotificationRequest request)
    {
        var notification = new Notification
        {
            UserId = request.UserId,
            Title = request.Title,
            Message = request.Message,
            Status = NotificationStatus.Pending,
            Channel = NotificationChannel.InApp
        };

        _context.Notifications.Add(notification);

        await _context.SaveChangesAsync();

        return notification.Id;
    }

    public async Task<List<NotificationResponse>>
        GetNotificationsByUserIdAsync(Guid userId)
    {
        return await _context.Notifications
            .Where(n => n.UserId == userId)
            .Select(n => new NotificationResponse
            {
                Id = n.Id,
                Title = n.Title,
                Message = n.Message,
                Status = n.Status,
                CreatedAt = n.CreatedAt
            })
            .ToListAsync();
    }

    public async Task MarkAsReadAsync(Guid notificationId)
    {
        var notification = await _context.Notifications
            .FirstOrDefaultAsync(n => n.Id == notificationId);

        if (notification is null)
            return;

        notification.Status = NotificationStatus.Read;
        notification.ReadAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
    }
}