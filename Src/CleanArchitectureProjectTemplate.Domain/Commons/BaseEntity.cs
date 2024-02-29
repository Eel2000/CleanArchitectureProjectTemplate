namespace CleanArchitectureProjectTemplate.Domain.Commons;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public bool? Active { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastUpdated { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid UpdatedBy { get; set; }
}
