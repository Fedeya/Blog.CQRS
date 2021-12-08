namespace Blog.Application.Posts.Commands.CreatePost;

public record CreatedPostDto(Guid Id, string? Title, string? Content);