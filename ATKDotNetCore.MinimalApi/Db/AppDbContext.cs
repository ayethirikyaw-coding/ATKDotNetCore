using ATKDotNetCore.MinimalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ATKDotNetCore.MinimalApi.Db;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }

    //Configure database connection
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
    //}

    public DbSet<BlogModel> Blogs { get; set; }
}