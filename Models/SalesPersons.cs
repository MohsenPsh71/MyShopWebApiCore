using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SampleWebApiCore.Models;

public partial class SalesPersons
{
    [Key]
    public int SalesPersonId { get; set; }

    [StringLength(150)]
    public string? FirstName { get; set; }

    [StringLength(150)]
    public string? LastName { get; set; }

    [StringLength(150)]
    public string? Email { get; set; }

    [StringLength(150)]
    public string? Phone { get; set; }

    [StringLength(150)]
    public string? Address { get; set; }

    [StringLength(150)]
    public string? City { get; set; }

    [StringLength(150)]
    public string? State { get; set; }

    [StringLength(150)]
    public string? ZipeCode { get; set; }

    [InverseProperty("SalesPersonNavigation")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
