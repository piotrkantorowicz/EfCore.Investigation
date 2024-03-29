using EfCore.Investigation.Domain;
using EfCore.Investigation.Domain.VO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCore.Investigation.Persistence.EfCore;

internal sealed class BudgetPermissionEntityTypeConfiguration : IEntityTypeConfiguration<BudgetPermission>
{
    public void Configure(EntityTypeBuilder<BudgetPermission> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .HasConversion(x => x.Value, x => BudgetPermissionId.Create(x))
            .IsRequired();

        builder.HasIndex(x => x.BudgetId).IsUnique();

        builder
            .Property(x => x.BudgetId)
            .HasConversion(x => x.Value, x => BudgetId.Create(x))
            .IsRequired();

        builder
            .Property(x => x.OwnerId)
            .HasConversion(x => x.Value, x => PersonId.Create(x))
            .IsRequired();

        builder.OwnsMany(x => x.Permissions, permissionsBuilder =>
        {
            permissionsBuilder
                .Property(x => x.ParticipantId)
                .HasConversion(x => x.Value, x => PersonId.Create(x))
                .IsRequired();

            permissionsBuilder
                .Property(x => x.PermissionType)
                .HasConversion(x => x.Value, x => PermissionType.Create(x))
                .IsRequired();
        });
    }
}