using System;
using System.Collections.Generic;

namespace Project_Prn212.Models;

public partial class Table
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
