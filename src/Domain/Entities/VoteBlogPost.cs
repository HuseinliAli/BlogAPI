using Domain.Enums;

namespace Domain.Entities;

public class VoteBlogPost:BaseEntity<int>
{
    public int BlogPostId { get; set; }
    public VoteType VoteType { get; set; }
    public Guid UserId { get; set; }
}
