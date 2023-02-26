using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace schadTestWeb.Models;

//[Table("Customer", Schema = "blogging")]
public class Customer
{
    public int Id { get; set; }
    [Display(Name = "Customer")]
    [Required]
    public string CustName { get; set; }
    public string Adress { get; set; }
    [Required]
    public bool Status { get; set; }
    [Required]
    public int CustomerTypeId { get; set; }
}