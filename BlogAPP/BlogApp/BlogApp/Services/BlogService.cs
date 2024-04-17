using BlogApp.Models;
using BlogApp.Respositories;
using BlogApp.ViewModels;

namespace BlogApp.Services;

public class BlogService
{
    private readonly BlogRepository blogRepository;

    public BlogService(BlogRepository blogRepository)
    {
        this.blogRepository = blogRepository;
    }
    public async Task<bool> SaveAsync(BlogCreateViewModel request)
    {
        
        Blog blog= new Blog()
        {
            Content = request.Content,
            Tags = request.Tags.Split(","),
            Title = request.Title,
            UserId = Guid.NewGuid(),

        };
        var result= await blogRepository.SaveAsync(blog);
        if (result == null) return false;
        return true;

    }
}
