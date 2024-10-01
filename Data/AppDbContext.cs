using Linkify.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Linkify.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Url> Urls { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
