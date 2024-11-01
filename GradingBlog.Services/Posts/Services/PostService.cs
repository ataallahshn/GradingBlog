using GradingBlog.DataLayer.Posts.Dtos.Request;
using GradingBlog.DataLayer.Posts.Dtos.Response;
using GradingBlog.DataLayer.Posts.Entities;
using GradingBlog.DataLayer.Posts.Repositories;

namespace GradingBlog.Services.Posts.Services;

internal sealed class PostService(
    IPostRepository postRepository,
    IPostHistoryRepository postHistoryRepository,
    ICommentRepository commentRepository) : IPostService
{
    public async Task<long> CreatePost(CreatePostRequestDto createPostRequestDto, CancellationToken ct)
    {
        var post = new Post(createPostRequestDto.Title, createPostRequestDto.Content);

        await postRepository.AddAsync(post, ct);

        return post.Id;
    }

    public async Task CreatePostHistory(
        CreatePostHistoryRequestDto createPostHistoryRequestDto,
        CancellationToken ct)
    {
        var postHistory = new PostHistory(
            createPostHistoryRequestDto.PostId,
            createPostHistoryRequestDto.From,
            createPostHistoryRequestDto.To,
            createPostHistoryRequestDto.ChangedOn);

        await postHistoryRepository.AddAsync(postHistory, ct);
    }

    public async Task UpdatePost(UpdatePostRequestDto updatePostRequestDto, CancellationToken ct)
    {
        var post = new Post(updatePostRequestDto.Title, updatePostRequestDto.Content)
        {
            Id = updatePostRequestDto.PostId
        };

        postRepository.Update(post);
    }

    public async Task<List<GetPostListResponseDto>> GetPostList(CancellationToken ct)
    {
        return await postRepository.GetList(ct);
    }

    public async Task<Post?> GetPostById(long postId, CancellationToken ct)
    {
        return await postRepository.GetById(postId, ct);
    }

    public async Task<long> CreateComment(CreateCommentRequestDto createCommentRequestDto, CancellationToken ct)
    {
        var comment = new Comment(createCommentRequestDto.Text, createCommentRequestDto!.PostId);

        await commentRepository.AddAsync(comment, ct);

        return comment.Id;
    }
}