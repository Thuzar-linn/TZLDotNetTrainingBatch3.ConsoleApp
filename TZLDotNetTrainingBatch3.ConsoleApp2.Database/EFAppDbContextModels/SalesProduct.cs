using System;
using System.Collections.Generic;

namespace TZLDotNetTrainingBatch3.ConsoleApp2.Database.EFAppDbContextModels;

public partial class SalesProduct
{
    public int SaleId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }
}
