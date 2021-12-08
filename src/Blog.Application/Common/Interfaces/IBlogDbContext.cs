using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Blog.Application.Common.Interfaces;

public interface IBlogDbContext
{
    DbSet<Post> Posts { get; }

    DbSet<Comment> Comments { get; }

    public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}