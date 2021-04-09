using Microsoft.EntityFrameworkCore;
using Munter.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Munter.Core.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<TrendingResponse> TrendingResponses { get; set; }
        public DbSet<SearchResponse> SearchResponses { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DateTime startActionTime = DateTime.Now;
            Guid adminUserId = Guid.NewGuid();
            modelBuilder.Entity<SearchResponse>(entity =>
            {
                entity.HasKey(x => x.ID);
                entity.Property(x => x.ID).ValueGeneratedOnAdd();

                entity.Property(x => x.CreatedTime)
                .HasDefaultValueSql("datetime('now')")
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TrendingResponse>(entity =>
            {
                entity.HasKey(x => x.ID);
                entity.Property(x => x.ID).ValueGeneratedOnAdd();

                entity.Property(x => x.CreatedTime)
                .HasDefaultValueSql("datetime('now')")
                .ValueGeneratedOnAdd();
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
