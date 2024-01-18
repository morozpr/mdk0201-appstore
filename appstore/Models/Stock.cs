using System;
using System.Collections.Generic;

namespace appstore.Models;

public partial class Stock
{
    public int StockId { get; set; }

    public string Position { get; set; } = null!;

    public bool IsOnStock { get; set; }

    public int ItemTypeId { get; set; }

    public string Description { get; set; } = null!;

    public int SupplyItemsId { get; set; }

    public virtual ItemType ItemType { get; set; } = null!;
}
