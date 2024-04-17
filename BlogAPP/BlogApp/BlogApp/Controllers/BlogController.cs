using BlogApp.Services;
using BlogApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers;

public class BlogController : Controller
{
    private readonly BlogService blogService;

    public BlogController(BlogService blogService)
    {
        this.blogService = blogService;
    }
    public IActionResult Save()
    {
        return View();
    }
    [HttpPost]
    public async Task< IActionResult> Save(BlogCreateViewModel request)
    {
        var result = await blogService.SaveAsync(request);
        if (!result)
        {
            TempData["result"] = "Kayıt Başarısız";
            return RedirectToAction(nameof(BlogController.Save));
        }
        TempData["result"] = "Kayıt Başarılı";
        return View();
    }
}
