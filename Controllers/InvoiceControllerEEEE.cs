using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using schadTestWeb.Models;
using schadTestWeb.ViewModels;

namespace schadTestWeb.Controllers
{
    public class InvoiceControllerEEEE : Controller
    {
        private readonly MvcTestInvoceContext _context;

        public InvoiceControllerEEEE(MvcTestInvoceContext context)
        {
            _context = context;
        }

        // GET: Invoice
        public async Task<IActionResult> Index()
        {
            return View(await _context.Invoice.ToListAsync());
        }

        // GET: Invoice/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoice == null)
            {
                return NotFound();
            }

            var invoiceDetail = await _context.InvoiceDetail
             .FirstOrDefaultAsync(m => m.InvoiceId == invoice.Id);

            return View(new InvoiceAndDetails
            {
                Invoice = invoice,
                InvoiceDetail = invoiceDetail

            });
        }

        // GET: Invoice/Create
        public IActionResult Create()
        {
            var customerList = (from Customer in _context.Customer
                                select new SelectListItem()
                                {
                                    Text = Customer.CustName,
                                    Value = Customer.Id.ToString()

                                }).ToList();

            ViewBag.CustomerId = customerList;

            return View();
        }

        // POST: Invoice/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TotalItbis,SubTotal,CustomerId")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                invoice.Total = invoice.SubTotal + invoice.TotalItbis;

                _context.Add(invoice);

                await _context.SaveChangesAsync();

                InvoiceDetail invoiceDetail = new InvoiceDetail();

                invoiceDetail.CustomerId = invoice.CustomerId;
                invoiceDetail.InvoiceId = invoice.Id;
                invoiceDetail.Qty = 1;
                invoiceDetail.TotalItbis = invoice.TotalItbis;
                invoiceDetail.SubTotal = invoice.SubTotal;
                invoiceDetail.Total = invoice.SubTotal + invoice.TotalItbis;
                invoiceDetail.Price = invoice.SubTotal;

                _context.Add(invoiceDetail);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(invoice);
        }

        // GET: Invoice/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }


            var customerList = await (from Customer in _context.Customer
                                      select new SelectListItem()
                                      {
                                          Text = Customer.CustName,
                                          Value = Customer.Id.ToString(),
                                          Selected = Customer.Id == invoice.CustomerId ? true : false
                                      }).ToListAsync();

            ViewBag.CustomerId = customerList;

            return View(invoice);
        }

        // POST: Invoice/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TotalItbis,SubTotal,Total,CustomerId")] Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    invoice.Total = invoice.SubTotal + invoice.TotalItbis;

                    _context.Update(invoice);

                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceExists(invoice.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(invoice);
        }

        // GET: Invoice/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Invoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoice = await _context.Invoice.FindAsync(id);
            _context.Invoice.Remove(invoice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoice.Any(e => e.Id == id);
        }
    }
}
