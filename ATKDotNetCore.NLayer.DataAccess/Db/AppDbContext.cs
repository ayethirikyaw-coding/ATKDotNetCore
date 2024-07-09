using ATKDotNetCore.NLayer.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace ATKDotNetCore.NLayer.DataAccess.Db
{
    internal class AppDbContext : DbContext
    {
        //Configure database connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BlogModel> Blogs { get; set; }
    }
}