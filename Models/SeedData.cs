using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using schadTestWeb.Models;
using System;
using System.Linq;

namespace schadTestWeb.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcTestInvoceContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcTestInvoceContext>>()))
            {
                // 
                if (context.Customer.Any())
                {
                    return;   // DB has been seeded
                }
                // DateTime.Parse("1989-2-12"),
                context.Customer.AddRange(
                    new Customer
                    {
                        CustName = "TEST SRL",
                        Adress = "Los Prados",
                        Status = true,
                        CustomerTypeId = 1
                    }
                );

                context.CustomerTypes.AddRange(
                   new CustomerTypes
                   {
                       Id = 1,
                       Description = "Dealer"
                   }
               );

                context.Invoice.AddRange(
                   new Invoice
                   {
                       Id = 1,
                       TotalItbis = 2.0m,
                       SubTotal = 10.0m,
                       Total = 12.0m,
                       CustomerId = 1
                   }
               );

                context.InvoiceDetail.AddRange(

                   new InvoiceDetail
                   {
                       Id = 1,
                       CustomerId = 1,
                       InvoiceId = 1,
                       Qty = 1,
                       Price = 10.0m,
                       TotalItbis = 2.0m,
                       SubTotal = 10.0m,
                       Total = 12.0m,
                   }
               );

                context.SaveChanges();
            }
        }
    }
}