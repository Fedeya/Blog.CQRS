namespace Blog.Application.Posts.Commands.AddComment;

public record AddedCommentDto(Guid Id, string? Content, int Likes);