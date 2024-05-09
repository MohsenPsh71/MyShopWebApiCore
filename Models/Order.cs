using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SampleWebApiCore.Models;

public partial class Order
{
    [Key]
    public int OrderId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Date { get; set; }

    public double? Total { get; set; }

    [StringLength(150)]
    public string? Status { get; set; }

    public int? CostomerId { get; set; }

    public int? SalesPerson { get; set; }

    [ForeignKey("CostomerId")]
    [InverseProperty("Orders")]
    public virtual Customer? Costomer { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    [ForeignKey("SalesPerson")]
    [InverseProperty("Orders")]
    public virtual SalesPerson? SalesPersonNavigation { get; set; }
}
