﻿using Microsoft.EntityFrameworkCore;
using SenacStore.API.Models;

namespace SenacStore.API.Data
{
    public class SenacStoreDbContext : DbContext
    {
        public SenacStoreDbContext(DbContextOptions<SenacStoreDbContext> options) : base(options)
        {
        }
        public DbSet<Produto> Produtos { get; set; }
    }
}
