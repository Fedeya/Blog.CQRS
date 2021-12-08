using FluentValidation;

namespace Blog.Application.Posts.Commands.CreatePost;

public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostCommandValidator()
    {
        RuleFor(v => v.Title)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(v => v.Content)
            .NotEmpty();
    }
}