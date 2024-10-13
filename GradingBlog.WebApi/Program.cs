using GradingBlog.Application;
using GradingBlog.Application.Posts.Dtos.Request;
using GradingBlog.Application.Posts.Dtos.Response;
using GradingBlog.Application.Posts.Services;
using GradingBlog.DataLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationDependencies();
builder.Services.AddDataLayerDependencies(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("/posts", async (
        [AsParameters] CreatePostRequestDto createPostRequestDto,
        IPostService postService,
        CancellationToken ct) =>
    {
        var result = await postService.CreatePost(createPostRequestDto, ct);

        return result;
    })
    .WithOpenApi();

app.MapGet("/posts", async (
        IPostService postService,
        CancellationToken ct) =>
    {
        var result = await postService.GetPostList(ct);

        return result;
    })
    .Produces<List<GetPostListResponseDto>>()
    .WithOpenApi();

app.MapPost("/posts/{postId}/comments", async (
        long postId,
        string text,
        IPostService postService,
        CancellationToken ct) =>
    {
        var createCommentRequestDto = new CreateCommentRequestDto
        {
            PostId = postId,
            Text = text
        };

        var result = await postService.CreateComment(createCommentRequestDto, ct);

        return result;
    })
    .WithOpenApi();

app.MapPut("/posts", async (
        [AsParameters] UpdatePostRequestDto updatePostRequestDto,
        IPostService postService,
        CancellationToken ct) =>
    {
        await postService.UpdatePost(updatePostRequestDto, ct);
    })
    .WithOpenApi();

app.Run();