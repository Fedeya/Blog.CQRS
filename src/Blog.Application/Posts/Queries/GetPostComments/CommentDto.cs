namespace Blog.Application.Posts.Queries.GetPostComments;

public record CommentDto(Guid Id, string? Content, int Likes);