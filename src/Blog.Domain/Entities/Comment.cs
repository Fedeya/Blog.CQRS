using Blog.Domain.Common;

namespace Blog.Domain.Entities;

public class Comment : AuditableEntity
{
    public string? Content { get; set; }

    public int Likes { get; set; } = 0;

    public Guid PostId { get; set; }
    public Post Post { get; set; }
}