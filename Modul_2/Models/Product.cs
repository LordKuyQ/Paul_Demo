using System;
using System.Collections.Generic;

namespace Modul_2.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Articul { get; set; }

    public int IdTypeProduct { get; set; }

    public string? UnitMeasure { get; set; }

    public double Cost { get; set; }

    public int IdProvider { get; set; }

    public int IdProducer { get; set; }

    public int IdCategoryProduct { get; set; }

    public int? Discount { get; set; }

    public int? CountOnStorage { get; set; }

    public string? Description { get; set; }

    public string? Photo { get; set; }

    public virtual ICollection<FkOrderProduct> FkOrderProducts { get; set; } = new List<FkOrderProduct>();

    public virtual CategoryProduct IdCategoryProductNavigation { get; set; } = null!;

    public virtual Producer IdProducerNavigation { get; set; } = null!;

    public virtual Provider IdProviderNavigation { get; set; } = null!;

    public virtual TypeProduct IdTypeProductNavigation { get; set; } = null!;
}
