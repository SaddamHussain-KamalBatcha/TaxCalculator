using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Repository.Entities;

namespace Repository.Context
{
    public class TaxDbContext : DbContext
    {
        public TaxDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TaxInfo> Taxes { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<TaxInfo>().HasData(new TaxInfo()
        //    {
        //       Municipality = "",
        //       FromDate = "2016.01.01",
        //       ToDate = "2016.12.31",
        //       TaxRate = "0.2"
        //    }, new TaxInfo()
        //    {
        //        Municipality = "",
        //        FromDate = "2016.01.01",
        //        ToDate = "2016.12.31",
        //        TaxRate = "0.2"
        //    });
        //}
    }
}
