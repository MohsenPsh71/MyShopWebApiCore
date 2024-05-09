using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SampleWebApiCore.Models;

public partial class Product
{
    [Key]
    public int ProductId { get; set; }

    [StringLength(150)]
    public string? ProductName { get; set; }

    public int? Size { get; set; }

    [StringLength(150)]
    public string? Varienty { get; set; }

    public double? Price { get; set; }

    [StringLength(150)]
    public string? Status { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
