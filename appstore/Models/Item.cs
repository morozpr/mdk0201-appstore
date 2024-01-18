using System;
using System.Collections.Generic;

namespace appstore.Models;

public partial class Item
{
    public int ItemId { get; set; }

    public string Name { get; set; } = null!;

    public int PriceId { get; set; }

    public int StockId { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Price Price { get; set; } = null!;
}
