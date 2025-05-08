using Microsoft.EntityFrameworkCore;
using Onepoint_Backend.Models;

namespace Onepoint_Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

       public DbSet<User> Users { get; set; }

       public DbSet<Attendance> Attendances { get; set; }
    
       public DbSet<FoodMenu> FoodMenus { get; set; }
        
       public DbSet<FoodOrder> FoodOrders { get; set; }
                
       public DbSet<Feedback> Feedbacks { get; set; }
        
       public DbSet<Notification> Notifications { get; set; }

    }

}