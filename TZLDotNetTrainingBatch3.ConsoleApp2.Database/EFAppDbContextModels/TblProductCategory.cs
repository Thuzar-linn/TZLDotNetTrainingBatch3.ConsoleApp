﻿using System;
using System.Collections.Generic;

namespace TZLDotNetTrainingBatch3.ConsoleApp2.Database.EFAppDbContextModels;

public partial class TblProductCategory
{
    public int ProductCategoryId { get; set; }

    public string ProductCategoryCode { get; set; } = null!;

    public string ProductCategoryName { get; set; } = null!;
}
