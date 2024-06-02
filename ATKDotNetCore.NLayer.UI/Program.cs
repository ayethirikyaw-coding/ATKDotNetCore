// See https://aka.ms/new-console-template for more information
using ATKDotNetCore.NLayer.BusinessLogic.Services;

Console.WriteLine("Hello, World!");

BL_Blog blBlog = new BL_Blog();
var lst = blBlog.GetBlogs();
foreach (var item in lst)
{
    Console.WriteLine(item.BlogId);
    Console.WriteLine(item.BlogTitle);
    Console.WriteLine(item.BlogAuthor);
    Console.WriteLine(item.BlogContent);
    Console.WriteLine("---------------------------------------------");
}


