using EfCore.Investigation.Domain;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Investigation.Persistence.EfCore;

internal sealed class BudgetSharingDbContext(DbContextOptions<BudgetSharingDbContext> options)
    : DbContext(options)
{
    public DbSet<BudgetPermission> BudgetPermissions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("BudgetSharing");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}