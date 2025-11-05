using System;
using System.Collections.Generic;

namespace Modul_2.Models;

public partial class CategoryProduct
{
    public int Id { get; set; }

    public string CategoryProduct1 { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
