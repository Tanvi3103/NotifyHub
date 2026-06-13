using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NotifyHub.Infrastructure.Data;

public class NotifyHubDbContextFactory : IDesignTimeDbContextFactory<NotifyHubDbContext>
{
    public NotifyHubDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<NotifyHubDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=NotifyHubDb;User Id=sa;Password=YourStrongPassword123!;TrustServerCertificate=True;");

        return new NotifyHubDbContext(optionsBuilder.Options);
    }
}