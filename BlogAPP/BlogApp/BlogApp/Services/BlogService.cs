using BlogApp.Respositories;

namespace BlogApp.Services;

public class BlogService
{
    private readonly BlogRepository blogRepository;

    public BlogService(BlogRepository blogRepository)
    {
        this.blogRepository = blogRepository;
    }
}
