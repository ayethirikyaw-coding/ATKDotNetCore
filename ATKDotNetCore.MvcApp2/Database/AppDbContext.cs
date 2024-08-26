using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATKDotNetCore.MvcApp2.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<BlogEntity> Blogs { get; set; }
}

//Data Model
[Table("Tbl_Blog")]
public class BlogEntity
{
    [Key]
    public int BlogId { get; set; }
    public string BlogAuthor { get; set; }
    public string BlogTitle { get; set; }
    public string BlogContent { get; set; }
}

//View Model
//public class BlogModel
//{

//}
