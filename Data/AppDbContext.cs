using System;
using Microsoft.EntityFrameworkCore;
using RSVPinvites.Models;


namespace RSVPinvites.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt): base(opt)
        {
            
        }

        public DbSet<RSVPinvite> RSVPinvites { get;set; }
    }
}