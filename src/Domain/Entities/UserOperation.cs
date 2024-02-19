namespace Domain.Entities;

public class UserOperation : BaseEntity<int>
{
    public Guid UserId { get; set; }
    public int OperationClaimId { get; set; }
}