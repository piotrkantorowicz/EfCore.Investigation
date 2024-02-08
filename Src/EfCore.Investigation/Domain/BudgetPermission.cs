using EfCore.Investigation.Domain.VO;

namespace EfCore.Investigation.Domain;

public class BudgetPermission
{
    // Required by EF Core   
    private BudgetPermission()
    {
    }

    private BudgetPermission(BudgetPermissionId id, BudgetId budgetId, PersonId ownerId)
    {
        Id = id;
        BudgetId = budgetId;
        OwnerId = ownerId;
        Permissions = new List<Permission>();
    }

    public BudgetPermissionId Id { get; }

    public BudgetId BudgetId { get; }

    public PersonId OwnerId { get; }

    public ICollection<Permission> Permissions { get; }

    public static BudgetPermission Create(BudgetId budgetId, PersonId ownerId)
    {
        return new BudgetPermission(Guid.NewGuid(), budgetId, ownerId);
    }
}