using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATKDotNetCore.MvcApp.Models;

[Table("tbl_Blog")]
public class BlogModel
{
    [Key]
    public int BlogId { get; set; }

    public string? BlogTitle { get; set; }

    public string? BlogAuthor { get; set; }

    public string? BlogContent { get; set; }
}

public class BlogMessageResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}
