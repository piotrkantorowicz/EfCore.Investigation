using EfCore.Investigation.Domain.VO;

namespace EfCore.Investigation.Domain;

public class Permission
{
    // Required by EF Core   
    private Permission()
    {
    }

    private Permission(PersonId participantId, PermissionType permissionType)
    {
        ParticipantId = participantId;
        PermissionType = permissionType;
    }

    public PersonId ParticipantId { get; }

    public PermissionType PermissionType { get; }

    internal static Permission Create(PersonId participantId, PermissionType permissionType)
    {
        return new Permission(participantId, permissionType);
    }
}