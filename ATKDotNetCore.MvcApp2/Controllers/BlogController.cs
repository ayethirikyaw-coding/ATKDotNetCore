using ATKDotNetCore.MvcApp2.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATKDotNetCore.MvcApp2.Controllers;

public class BlogController : Controller
{
    private readonly AppDbContext _db;

    //constructor injection
    public BlogController(AppDbContext db)
    {
        _db = db;
    }
    //logical path => http://localhost:/home/blog/index
    //physical path => http://localhost:/home/blog/blogindex
    //[ActionName("Index")]
    //public IActionResult BlogIndex([FromServices] AppDbContext db)//method injection
    //{
    //    return View("BlogIndex");
    //}

    //[FromServices]
    //public AppDbContext db { get; set; }    //property injection

    //CRUD

    //Read
    [HttpGet]
    [ActionName("Index")]
    public IActionResult BlogIndex()
    {
        var lst = _db.Blogs
            .AsNoTracking()
            .OrderByDescending(x => x.BlogId)
            .ToList();
        return View("BlogIndex", lst);
    }

    //Create
    [HttpGet]
    [ActionName("Create")]
    public IActionResult BlogCreate()
    {
        return View("BlogCreate");
    }

    //Save
    [HttpPost]
    [ActionName("Save")]
    public async Task<IActionResult> BlogSave(BlogEntity blog)
    {
        _db.Blogs.Add(blog);
        int result = await _db.SaveChangesAsync();
        string message = result > 0 ? "Saving Successful." : "Saving failed";
        return Json(new
        {
            IsSuccess = result > 0,
            Message = message
        });
    }

    //Edit
    [HttpGet]
    [ActionName("Edit")]
    public async Task<IActionResult> BlogEdit(int blogId)
    {
        var item = await _db.Blogs.FirstOrDefaultAsync(x => x.BlogId == blogId);
        if (item is null) return RedirectToAction("Index");
        return View("BlogEdit",item);
    }

    //Delete
    [HttpPost]
    [ActionName("Update")]
    public async Task<IActionResult> BlogUpdate(int blogId, BlogEntity blog)
    {
        var item = await _db.Blogs
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.BlogId == blogId);
        if (item is null) return Json(new
        {
            IsSuccess = false,
            Message = "No data found."
        });

        item.BlogTitle = blog.BlogTitle;
        item.BlogAuthor = blog.BlogAuthor;
        item.BlogContent = blog.BlogContent;

        _db.Entry(item).State = EntityState.Modified;
        int result = await _db.SaveChangesAsync();
        string message = result > 0 ? "Updating Successful." : "Updating failed";
        return Json(new
        {
            IsSuccess = result > 0,
            Message = message
        });
    }

    //Delete
    [HttpPost]
    [ActionName("Delete")]
    public async Task<IActionResult> BlogDelete(BlogEntity blog)
    {
        var item = await _db.Blogs
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.BlogId == blog.BlogId);
        if (item is null) return Json(new
        {
            IsSuccess = false,
            Message = "No data found."
        });

        _db.Entry(item).State = EntityState.Deleted;
        int result = await _db.SaveChangesAsync();
        string message = result > 0 ? "Deleting Successful." : "Deleting failed";
        return Json(new
        {
            IsSuccess = result > 0,
            Message = message
        });
    }
}
