using System.Text.Json;
using GradingBlog.Application.Posts.Dtos.Request;
using GradingBlog.Application.Posts.Dtos.Response;
using GradingBlog.DataLayer;
using GradingBlog.DataLayer.Posts;
using GradingBlog.Seedwork.Guards;
using Microsoft.EntityFrameworkCore;

namespace GradingBlog.Application.Posts.Services;

public sealed class PostService(DataContext dataContext) : IPostService
{
    public async Task<long> CreatePost(CreatePostRequestDto createPostRequestDto, CancellationToken ct)
    {
        var post = new Post(createPostRequestDto.Title, createPostRequestDto.Content);

        await dataContext.Posts.AddAsync(post, ct);

        await dataContext.SaveChangesAsync(ct);

        return post.Id;
    }

    public async Task UpdatePost(UpdatePostRequestDto updatePostRequestDto, CancellationToken ct)
    {
        var post = await dataContext.Posts.SingleOrDefaultAsync(post => post.Id == updatePostRequestDto.PostId, ct);

        Guard.Against.Null(post, new Exception("شناسه پست معتبر نیست"));

        var postHistory = new PostHistory(
            post!.Id,
            JsonSerializer.Serialize(post),
            JsonSerializer.Serialize(updatePostRequestDto),
            DateTime.Now);

        post!.Title = updatePostRequestDto.Title;
        post.Content = updatePostRequestDto.Content;

        dataContext.Posts.Update(post);

        await dataContext.PostHistories.AddAsync(postHistory, ct);

        await dataContext.SaveChangesAsync(ct);
    }

    public async Task<List<GetPostListResponseDto>> GetPostList(CancellationToken ct)
    {
        var posts = await dataContext
            .Posts
            .AsNoTracking()
            .Select(post => new GetPostListResponseDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Comments = post.Comments.Select(comment => new GetPostListCommentResponseDto
                {
                    Id = comment.Id,
                    Text = comment.Text
                }).ToList()
            })
            .ToListAsync(ct);

        return posts;
    }

    public async Task<long> CreateComment(CreateCommentRequestDto createCommentRequestDto, CancellationToken ct)
    {
        var post = await dataContext.Posts.SingleOrDefaultAsync(post => post.Id == createCommentRequestDto.PostId, ct);

        Guard.Against.Null(post, new Exception("شناسه پست معتبر نیست"));

        var comment = new Comment(createCommentRequestDto.Text, post!.Id);

        await dataContext.Comments.AddAsync(comment, ct);

        await dataContext.SaveChangesAsync(ct);

        return comment.Id;
    }
}