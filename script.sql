SELECT * FROM [GradingBlog].[dbo].[Post] AS post
WHERE (SELECT COUNT(*) FROM [GradingBlog].[dbo].Comment WHERE PostId = post.Id) = 1
ORDER BY Id DESC

SELECT post.Id,post.Title,post.Content FROM [GradingBlog].[dbo].[Post] AS post
    LEFT JOIN [GradingBlog].[dbo].[Comment] AS comment ON post.Id = comment.PostId
GROUP BY post.Id, post.Title, post.Content
HAVING COUNT(comment.Id) = 1;

SELECT
    post.Id AS PostId,
    post.Title AS 'Current Title',
        post.Content AS 'Current Content',
        history.[Id] AS PostHistoryId,
    history.[From] AS 'Last Post Detail'
FROM [GradingBlog].[dbo].[Post] AS post
    LEFT JOIN [GradingBlog].[dbo].[PostHistory] AS history ON
    history.PostId = post.Id and
    history.Id = (SELECT MAX(Id) FROM [GradingBlog].[dbo].[PostHistory] WHERE PostId = history.PostId)