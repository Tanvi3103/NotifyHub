using NotifyHub.Domain.Common;

namespace NotifyHub.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public ICollection<Notification> Notifications { get; set; }
        = new List<Notification>();
}