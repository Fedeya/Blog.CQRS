using AutoMapper;
using Blog.Application.Common.Interfaces;
using Blog.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Posts.Commands.AddComment;

public class AddCommentCommand : IRequest<AddedCommentDto>
{
    public Guid PostId { get; set; }

    public string? Content { get; set; }
}

public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, AddedCommentDto>
{
    private readonly IMapper _mapper;
    private readonly IBlogDbContext _context;

    public AddCommentCommandHandler(IBlogDbContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<AddedCommentDto> Handle(AddCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = _mapper.Map<Comment>(request);

        _context.Comments.Add(comment);

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<AddedCommentDto>(comment);
    }
}