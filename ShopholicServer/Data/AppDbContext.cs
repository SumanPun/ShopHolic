﻿using Microsoft.EntityFrameworkCore;
using ShopholiSharedLibrary.Models;

namespace ShopholicServer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = default!;
    }
}
