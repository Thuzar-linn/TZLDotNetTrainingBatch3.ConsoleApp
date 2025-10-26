using System;
using System.Collections.Generic;

namespace TZLDotNetTrainingBatch3.ConsoleApp2.Database.EFAppDbContextModels;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public bool DeleteFlag { get; set; }
}
