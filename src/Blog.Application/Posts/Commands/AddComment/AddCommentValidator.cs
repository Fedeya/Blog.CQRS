using Blog.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Posts.Commands.AddComment;

public class AddCommentValidator : AbstractValidator<AddCommentCommand>
{
    private readonly IBlogDbContext _context;

    public AddCommentValidator(IBlogDbContext context)
    {
        _context = context;

        RuleFor(v => v.Content)
            .NotEmpty();

        RuleFor(v => v.PostId)
            .NotEmpty()
            .MustAsync(ExistPost).WithMessage("Not exist post with id {PropertyValue}");
    }

    private async Task<bool> ExistPost(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Posts.AnyAsync(p => p.Id == id, cancellationToken);
    }
}