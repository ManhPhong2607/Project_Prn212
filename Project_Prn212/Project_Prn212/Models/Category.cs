using System;
using System.Collections.Generic;

namespace Project_Prn212.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();
}
