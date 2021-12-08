namespace Blog.Application.Posts.Queries.GetPostWithComments;

public record PostCommentDto(Guid Id, string? Content, int Likes);

public record PostWithCommentsDto(Guid Id, string? Title, string? Content, List<PostCommentDto> Comments);