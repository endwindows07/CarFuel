using System;
using CarFuel.Models;
using Microsoft.EntityFrameworkCore;

namespace CarFuel.Services.Data
{
    public class AppDB: DbContext
    {
        public AppDB(DbContextOptions<AppDB> options) : base(options)
        {

        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FillUp>().ToTable("FillUps");

            modelBuilder.Entity<Member>().Property(it => it.Lavel).HasConversion<string>();

            modelBuilder.Entity<Member>().HasQueryFilter(it => it.IsDeleted); // condition เพื่อเช็คการทำงาน
        }
    }
}
