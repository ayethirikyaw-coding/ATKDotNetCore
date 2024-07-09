using ATKDotNetCore.MvcApp.Db;
using ATKDotNetCore.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATKDotNetCore.MvcApp.Controllers
{
    public class BlogAjaxController : Controller
    {
        private readonly AppDbContext _context;

        public BlogAjaxController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //select * from Tbl_Blog with (nolock)

            var lst = await _context.Blogs
                .AsNoTracking()
                .OrderByDescending(x => x.BlogId)
                .ToListAsync();
            return View(lst);
        }

        [ActionName("Create")]
        public IActionResult BlogCreate()
        {
            return View("BlogCreate");
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> BlogCreate(BlogModel blog)
        {
            await _context.Blogs.AddAsync(blog);
            int result = await _context.SaveChangesAsync();
            //return View("BlogCreate");
            //return Redirect("/Blog");
            string message = result > 0 ? "Saving Successful." : "Saving Failed";

            BlogMessageResponseModel model = new BlogMessageResponseModel()
            {
                IsSuccess = result > 0,
                Message = message
            };
            return Json(model);
        }

        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> BlogEdit(int id)
        {
            var item = await _context.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
            if(item is null)
            {
                return Redirect("/Blog");
            }
            return View("BlogEdit", item);
        }

        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> BlogUpdate(int id, BlogModel blog)
        {
            BlogMessageResponseModel model = new BlogMessageResponseModel();
            var item = await _context.Blogs
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.BlogId == id);
            if (item is null)
            {
                model.IsSuccess = false;
                model.Message = "No data found.";
                return Json(model);
            }

            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;

            _context.Entry(item).State = EntityState.Modified;

            int result = await _context.SaveChangesAsync();
            string message = result > 0 ? "Updating Successful." : "Updating Failed";

            model = new BlogMessageResponseModel()
            {
                IsSuccess = result > 0,
                Message = message
            };
            return Json(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> BlogDelete(BlogModel blog)
        {
            BlogMessageResponseModel model = new BlogMessageResponseModel();
            var item = await _context.Blogs.FirstOrDefaultAsync(x => x.BlogId == blog.BlogId);
            if (item is null)
            {
                model.IsSuccess = false;
                model.Message = "No data found.";
                return Json(model);
            }

            _context.Blogs.Remove(item);

            int result = await _context.SaveChangesAsync();
            string message = result > 0 ? "Deleting Successful." : "Deleting Failed";

            model = new BlogMessageResponseModel()
            {
                IsSuccess = result > 0,
                Message = message
            };
            return Json(model);
        }
    }
}
