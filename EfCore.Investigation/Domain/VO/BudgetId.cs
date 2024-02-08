namespace EfCore.Investigation.Domain.VO;

public sealed class BudgetId
{
    private BudgetId(Guid value)
    {        
        Value = value;
    }

    public Guid Value { get; }

    public static implicit operator Guid(BudgetId id)
    {
        return id.Value;
    }

    public static implicit operator BudgetId(Guid id)
    {
        return new BudgetId(id);
    }

    public static BudgetId Create(Guid value)
    {
        return new BudgetId(value);
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}