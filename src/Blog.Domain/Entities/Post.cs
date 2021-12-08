using Blog.Domain.Common;

namespace Blog.Domain.Entities;

public class Post : AuditableEntity
{
    public string? Title { get; set; }

    public string? Content { get; set; }

    public ICollection<Comment> Comments = new HashSet<Comment>();
}