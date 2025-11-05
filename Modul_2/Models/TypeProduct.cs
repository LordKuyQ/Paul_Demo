using System;
using System.Collections.Generic;

namespace Modul_2.Models;

public partial class TypeProduct
{
    public int Id { get; set; }

    public string TypeProduct1 { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
