using DomainModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class DataDBContext : IdentityDbContext
    {
        public DataDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Item> Items { get; set; }
    }
}
