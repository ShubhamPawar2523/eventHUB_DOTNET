using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.DTOs;
using WebApplication2.Models;

namespace WebApplication1.Data
{
    public class MyDbContext : IdentityDbContext<ApplicationUser>
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<WebApplication1.DTOs.RoleStore>? RoleStore { get; set; }
        public DbSet<WebApplication2.Models.Booking>? Booking { get; set; }
        public DbSet<WebApplication1.Models.Contact>? Contact { get; set; }
       
       
    }
}
