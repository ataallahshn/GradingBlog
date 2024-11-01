using GradingBlog.Services;
using GradingBlog.Services.Posts.Services;
using GradingBlog.DataLayer;
using GradingBlog.DataLayer.Posts.Dtos.Response;
using GradingBlog.Services.Posts.Command.CreateComment;
using GradingBlog.Services.Posts.Command.CreatePost;
using GradingBlog.Services.Posts.Command.UpdatePost;
using GradingBlog.Services.Posts.Query.GetPostListQuery;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

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
        [AsParameters] CreatePostCommand command,
        IMediator mediator,
        CancellationToken ct) =>
    {
        return await mediator.Send(command, ct);
    })
    .WithOpenApi();

app.MapGet("/posts", async (
        IMediator mediator,
        CancellationToken ct) =>
    {
        return await mediator.Send(new GetPostListQuery(), ct);
    })
    .Produces<List<GetPostListResponseDto>>()
    .WithOpenApi();

app.MapPost("/posts/{postId}/comments", async (
        [AsParameters] CreateCommentCommand command,
        IMediator mediator,
        CancellationToken ct) =>
    {
        return await mediator.Send(command, ct);
    })
    .WithOpenApi();

app.MapPut("/posts", async (
        [AsParameters] UpdatePostCommand command,
        IMediator mediator,
        CancellationToken ct) =>
    {
        await mediator.Send(command, ct);
    })
    .WithOpenApi();

app.Run();