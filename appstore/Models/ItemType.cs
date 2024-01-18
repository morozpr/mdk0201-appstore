using System;
using System.Collections.Generic;

namespace appstore.Models;

public partial class ItemType
{
    public int ItemTypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
