namespace EfCore.Investigation.Domain.VO;

public sealed class PersonId
{
    private PersonId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static implicit operator Guid(PersonId id)
    {
        return id.Value;
    }

    public static implicit operator PersonId(Guid id)
    {
        return new PersonId(id);
    }

    public static PersonId Create(Guid value)
    {
        return new PersonId(value);
    }
    
    public override string ToString()
    {
        return Value.ToString();
    }
}