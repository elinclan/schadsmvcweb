using System.ComponentModel.DataAnnotations;

namespace schadTestWeb.Models;
public class Invoice
{
    public int Id { get; set; }
    public decimal TotalItbis { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Total { get; set; }
    public int CustomerId { get; set; }
}