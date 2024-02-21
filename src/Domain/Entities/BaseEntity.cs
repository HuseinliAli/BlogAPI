
namespace Domain.Entities;

public abstract class BaseEntity<T>:IEntity
{
    public T Id { get; set; }
    public DateTime CreatedAt { get; set ; }
    public DateTime? UpdatedAt { get ; set ; }
    public bool IsDelete { get ; set; }
    public DateTime? DeletedAt { get; set; }
}
