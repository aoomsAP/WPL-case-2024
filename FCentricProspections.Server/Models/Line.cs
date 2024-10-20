﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FCentricProspections.Server.Models;

public partial class Line
{
    public long Id { get; set; }

    public string Name { get; set; }

    public long UserCreatedId { get; set; }

    public DateTime DateCreated { get; set; }

    public byte[] Timestamp { get; set; }

    public virtual ICollection<ProductLine> ProductLines { get; set; } = new List<ProductLine>();

    public virtual ICollection<ShopLine> ShopLines { get; set; } = new List<ShopLine>();

    public virtual User UserCreated { get; set; }
}