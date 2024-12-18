﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FCentricProspections.Server.DataModels;

public partial class Brand
{
    public long Id { get; set; }

    public string Name { get; set; }

    public long UserCreatedId { get; set; }

    public DateTime DateCreated { get; set; }

    public byte[] Timestamp { get; set; }

    public string Code { get; set; }

    public long? Ean { get; set; }

    public double? MinBulkDeliveryPercentage { get; set; }

    public double? DeliveryFeePercentage { get; set; }

    public virtual ICollection<ProductLine> ProductLines { get; set; } = new List<ProductLine>();

    public virtual User UserCreated { get; set; }
}