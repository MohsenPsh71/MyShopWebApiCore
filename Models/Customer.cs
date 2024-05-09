using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SampleWebApiCore.Models;

[Table("Customer")]
public partial class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [StringLength(150)]
    public string? FirstName { get; set; }

    [StringLength(150)]
    public string? LastName { get; set; }

    [StringLength(150)]
    public string? Email { get; set; }

    [StringLength(150)]
    public string? Phone { get; set; }

    [StringLength(150)]
    public string? Adress { get; set; }

    [StringLength(150)]
    public string? City { get; set; }

    [StringLength(150)]
    public string? State { get; set; }

    [StringLength(150)]
    public string? ZipCode { get; set; }

    [InverseProperty("Costomer")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
