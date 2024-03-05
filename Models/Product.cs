using System;
using System.Collections.Generic;

namespace WebApplication90.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Productname { get; set; } = null!;

    public double Price { get; set; }

    public int Qty { get; set; }
}
