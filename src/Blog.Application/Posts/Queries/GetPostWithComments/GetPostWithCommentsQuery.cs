using AutoMapper;
using Blog.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Posts.Queries.GetPostWithComments;

public class GetPostWithCommentsQuery : IRequest<PostWithCommentsDto>
{
    public Guid Id { get; set; }
}

public class GetPostWithCommentsQueryHandler : IRequestHandler<GetPostWithCommentsQuery, PostWithCommentsDto>
{
    private readonly IMapper _mapper;
    private readonly IBlogDbContext _context;

    public GetPostWithCommentsQueryHandler(IBlogDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PostWithCommentsDto> Handle(GetPostWithCommentsQuery request, CancellationToken cancellationToken)
    {
        var post = await _context.Posts.SingleOrDefaultAsync(p => p.Id == request.Id,
            cancellationToken);

        if (post == null)
        {
            throw new Exception("Not found Post");
        }

        await _context.Entry(post)
            .Collection(p => p.Comments)
            .LoadAsync(cancellationToken);

        return _mapper.Map<PostWithCommentsDto>(post);
    }
}