using System;
using System.Collections.Generic;

namespace TZLDotNetTrainingBatch3.ConsoleApp2.Database.EFAppDbContextModels;

public partial class Sale
{
    public int SaleId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public bool DeleteFlag { get; set; }

    public DateTime CreateDateTime { get; set; }
}
