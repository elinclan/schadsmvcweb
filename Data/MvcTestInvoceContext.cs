using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using schadTestWeb.Models;


    public class MvcTestInvoceContext : DbContext
    {
        public MvcTestInvoceContext (DbContextOptions<MvcTestInvoceContext> options)
            : base(options)
        {
        }

        public DbSet<schadTestWeb.Models.Customer> Customer { get; set; }

        public DbSet<schadTestWeb.Models.CustomerTypes> CustomerTypes { get; set; }

        public DbSet<schadTestWeb.Models.Invoice> Invoice { get; set; }

        public DbSet<schadTestWeb.Models.InvoiceDetail> InvoiceDetail { get; set; }
    }
