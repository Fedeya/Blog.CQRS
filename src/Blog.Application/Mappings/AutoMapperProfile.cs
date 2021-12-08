using AutoMapper;
using Blog.Application.Posts.Commands.AddComment;
using Blog.Application.Posts.Commands.CreatePost;
using Blog.Application.Posts.Queries.GetPostWithComments;
using Blog.Application.Posts.Queries.GetPostComments;
using Blog.Application.Posts.Queries.GetPosts;
using Blog.Domain.Entities;

namespace Blog.Application.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Post, CreatePostCommand>().ReverseMap();
        CreateMap<Post, PostDto>().ReverseMap();
        CreateMap<Post, PostWithCommentsDto>().ReverseMap();
        CreateMap<Post, CreatedPostDto>().ReverseMap();

        CreateMap<Comment, CommentDto>().ReverseMap();
        CreateMap<Comment, PostCommentDto>().ReverseMap();
        CreateMap<Comment, AddCommentCommand>().ReverseMap();
        CreateMap<Comment, AddedCommentDto>().ReverseMap();
    }
}