﻿using System;
using System.Collections.Generic;

namespace BeautyShop.Models;

public partial class Manufacturer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? StartDate { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
