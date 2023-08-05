using B.Core.Data;
using Microsoft.EntityFrameworkCore;
using B.Models;

namespace B.API.Data;

public sealed class ApiContext : DbContext, IUnitOfWork
{
    public ApiContext(DbContextOptions<ApiContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        ChangeTracker.AutoDetectChangesEnabled = false;
    }

    public DbSet<Card> Cards { get; set; }

    public async Task<bool> Commit()
    {
        return await SaveChangesAsync() > 0;
    }
}