namespace Blog.Domain.Common;

public class AuditableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime Created { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime LastModified { get; set; }

    public Guid LastModifiedBy { get; set; }
}