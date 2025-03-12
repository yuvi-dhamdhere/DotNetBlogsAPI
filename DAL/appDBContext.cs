using CustomBlogsAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CustomBlogsAPI.DAL
{
    public class appDBContext : DbContext
    {
        public appDBContext(DbContextOptions<appDBContext> appDB) : base(appDB) {   }
        public DbSet<myBlogsEntity> myBlogs { get; set; }
        public DbSet<myCategoryEntity> myCategory { get; set; }
    }
}
