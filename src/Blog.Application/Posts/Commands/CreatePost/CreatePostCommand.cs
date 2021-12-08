using AutoMapper;
using Blog.Application.Common.Interfaces;
using Blog.Domain.Entities;
using MediatR;

namespace Blog.Application.Posts.Commands.CreatePost;

public class CreatePostCommand : IRequest<CreatedPostDto>
{
    public string? Title { get; set; }

    public string? Content { get; set; }
}

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, CreatedPostDto>
{
    private readonly IMapper _mapper;
    private readonly IBlogDbContext _context;

    public CreatePostCommandHandler(IBlogDbContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<CreatedPostDto> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var post = _mapper.Map<Post>(request);

        _context.Posts.Add(post);

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CreatedPostDto>(post);
    }
}