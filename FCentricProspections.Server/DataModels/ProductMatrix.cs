﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FCentricProspections.Server.DataModels;

public partial class ProductMatrix
{
    public long Id { get; set; }

    public string Pattern { get; set; }

    public string Name { get; set; }

    public long UserCreatedId { get; set; }

    public DateTime DateCreated { get; set; }

    public byte[] Timestamp { get; set; }

    public int? ModelCodeOrder { get; set; }

    public int? ProductCodeOrder { get; set; }

    public int? WashingCodeOrder { get; set; }

    public int? FabricCodeOrder { get; set; }

    public virtual ICollection<SalesCondition> SalesConditions { get; set; } = new List<SalesCondition>();

    public virtual User UserCreated { get; set; }
}