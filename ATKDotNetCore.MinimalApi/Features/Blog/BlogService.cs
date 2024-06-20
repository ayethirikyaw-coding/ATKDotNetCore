using ATKDotNetCore.MinimalApi.Db;
using Microsoft.EntityFrameworkCore;
using ATKDotNetCore.MinimalApi.Models;

namespace ATKDotNetCore.MinimalApi.Features.Blog
{
    public static class BlogService
    {
        public static void MapBlogs(this IEndpointRouteBuilder app)
        {
            app.MapGet("api/Blog", async (AppDbContext db) =>
            {
                var lst = await db.Blogs.AsNoTracking().ToListAsync();
                return Results.Ok(lst);
            });

            app.MapPost("api/Blog", async (AppDbContext db, BlogModel blog) =>
            {
                await db.Blogs.AddAsync(blog);
                var result = await db.SaveChangesAsync();

                string message = result > 0 ? "Saving successful.." : "Saving failed";
                return Results.Ok(message);
            });

            app.MapPut("api/Blog/{id}", async (AppDbContext db, int id, BlogModel blog) =>
            {
                var item = await db.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.NotFound("No data found");
                }
                item.BlogTitle = blog.BlogTitle;
                item.BlogAuthor = blog.BlogAuthor;
                item.BlogContent = blog.BlogContent;
                int result = db.SaveChanges();

                string message = result > 0 ? "Updating successful.." : "Updating failed";
                return Results.Ok(message);
            });

            app.MapDelete("api/Blog/{id}", async (AppDbContext db, int id) =>
            {
                var item = await db.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);

                if (item is null)
                {
                    return Results.NotFound("No data found");
                }

                db.Blogs.Remove(item);
                int result = await db.SaveChangesAsync();

                string message = result > 0 ? "Deleting successful.." : "Deleting failed";
                return Results.Ok(message);
            });
        }
    }
}
