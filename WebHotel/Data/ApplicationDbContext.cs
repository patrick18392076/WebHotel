using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebHotel.Models;

namespace WebHotel.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebHotel.Models.Room> Room { get; set; }
        public DbSet<WebHotel.Models.Customer> Customer { get; set; }
        public DbSet<WebHotel.Models.Booking> Booking { get; set; }
    }
}
