using Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Persistence.Database
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<User> user { get; set; }
    }
}
