using Blog.Application.Posts.Commands.AddComment;
using Blog.Application.Posts.Commands.CreatePost;
using Blog.Application.Posts.Queries.GetPostComments;
using Blog.Application.Posts.Queries.GetPosts;
using Blog.Application.Posts.Queries.GetPostWithComments;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<PostDto>> Get()
        {
            return await _mediator.Send(new GetPostsQuery());
        }

        [HttpPost]
        public async Task<CreatedPostDto> Create(CreatePostCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("{id}")]
        public async Task<PostWithCommentsDto> GetOne(Guid id)
        {
            return await _mediator.Send(new GetPostWithCommentsQuery()
            {
                Id = id
            });
        }

        [HttpPost("comments")]
        public async Task<AddedCommentDto> CreateComment(AddCommentCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("{id}/comments")]
        public async Task<List<CommentDto>> GetPostComments(Guid id)
        {
            return await _mediator.Send(new GetPostCommentsQuery() { Id = id });
        }
    }
}