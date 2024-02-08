namespace EfCore.Investigation.Domain.VO;

public sealed class BudgetPermissionId
{
    private BudgetPermissionId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static implicit operator Guid(BudgetPermissionId id)
    {
        return id.Value;
    }

    public static implicit operator BudgetPermissionId(Guid id)
    {
        return new BudgetPermissionId(id);
    }

    public static BudgetPermissionId Create(Guid value)
    {
        return new BudgetPermissionId(value);
    }
    
    public override string ToString()
    {
        return Value.ToString();
    }
}