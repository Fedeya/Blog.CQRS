namespace Blog.Application.Posts.Queries.GetPosts;

public record PostDto(Guid Id, string? Title, string? Content);