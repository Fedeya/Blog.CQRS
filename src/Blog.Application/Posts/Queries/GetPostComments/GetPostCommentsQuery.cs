using AutoMapper;
using AutoMapper.QueryableExtensions;
using Blog.Application.Common.Interfaces;
using Blog.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Posts.Queries.GetPostComments;

public class GetPostCommentsQuery : IRequest<List<CommentDto>>
{
    public Guid Id { get; set; }
}

public class GetPostCommentsQueryHandler : IRequestHandler<GetPostCommentsQuery, List<CommentDto>>
{
    private readonly IMapper _mapper;
    private readonly IBlogDbContext _context;

    public GetPostCommentsQueryHandler(IBlogDbContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<List<CommentDto>> Handle(GetPostCommentsQuery request, CancellationToken cancellationToken)
    {
        var comments = await _context.Comments
            .Where(c => c.PostId == request.Id)
            .ProjectTo<CommentDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return comments;
    }
}