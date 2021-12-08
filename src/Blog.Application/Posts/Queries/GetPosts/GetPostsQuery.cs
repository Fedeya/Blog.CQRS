using AutoMapper;
using AutoMapper.QueryableExtensions;
using Blog.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Posts.Queries.GetPosts;

public class GetPostsQuery : IRequest<List<PostDto>>
{
}

public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, List<PostDto>>
{
    private readonly IMapper _mapper;
    private readonly IBlogDbContext _context;

    public GetPostsQueryHandler(IBlogDbContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<List<PostDto>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
    {
        var posts = await _context.Posts
            .ProjectTo<PostDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return posts;
    }
}