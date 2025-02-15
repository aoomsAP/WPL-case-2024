﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FCentricProspections.Server.DataModels;

public partial class ProductLine
{
    public long Id { get; set; }

    public string Code { get; set; }

    public long BrandId { get; set; }

    public long LineId { get; set; }

    public long GenderId { get; set; }

    public long AgeCategoryId { get; set; }

    public long SegmentTypeId { get; set; }

    public decimal AveragePrice { get; set; }

    public int RadiusExclusivity { get; set; }

    public int FashionLevel { get; set; }

    public bool IsCompetitor { get; set; }

    public string Name { get; set; }

    public long UserCreatedId { get; set; }

    public DateTime DateCreated { get; set; }

    public byte[] Timestamp { get; set; }

    public virtual Brand Brand { get; set; }

    public virtual ICollection<ProductLineDelivery> ProductLineDeliveries { get; set; } = new List<ProductLineDelivery>();

    public virtual User UserCreated { get; set; }
}