using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _02_Layout.Areas.Admin.Models;

namespace _02_Layout.Data
{
    public class _02_LayoutContext : DbContext
    {
        public _02_LayoutContext (DbContextOptions<_02_LayoutContext> options)
            : base(options)
        {
        }

        public DbSet<_02_Layout.Areas.Admin.Models.Accounts> Accounts { get; set; }

        public DbSet<_02_Layout.Areas.Admin.Models.Products> Products { get; set; }

        public DbSet<_02_Layout.Areas.Admin.Models.ProductTypes> ProductTypes { get; set; }

        public DbSet<_02_Layout.Areas.Admin.Models.Carts> Carts { get; set; }

        public DbSet<_02_Layout.Areas.Admin.Models.Ads> Ads { get; set; }

        public DbSet<_02_Layout.Areas.Admin.Models.Invoices> Invoices { get; set; }

        public DbSet<_02_Layout.Areas.Admin.Models.InvoiceDetails> InvoiceDetails { get; set; }
    }
}
