using System;
using System.Collections.Generic;

namespace Modul_2.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateOnly? DateOrder { get; set; }

    public DateOnly? DateDelivery { get; set; }

    public int IdAdress { get; set; }

    public int IdClient { get; set; }

    public int Code { get; set; }

    public int IdStatus { get; set; }

    public virtual ICollection<FkOrderProduct> FkOrderProducts { get; set; } = new List<FkOrderProduct>();

    public virtual Adress IdAdressNavigation { get; set; } = null!;

    public virtual User IdClientNavigation { get; set; } = null!;

    public virtual Status IdStatusNavigation { get; set; } = null!;
}
