﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FCentricProspections.Server.Models;

public partial class SalesPeriodType
{
    public long Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public long UserCreatedId { get; set; }

    public DateTime DateCreated { get; set; }

    public byte[] Timestamp { get; set; }

    public DateTime? MainDeliveryStartDate { get; set; }

    public DateTime? MainDeliveryStopDate { get; set; }

    public DateTime? MainAcceptDeliveryDate { get; set; }

    public DateTime? PreDeliveryStartDate { get; set; }

    public DateTime? PreDeliveryStopDate { get; set; }

    public DateTime? PreAcceptDeliveryDate { get; set; }

    public virtual ICollection<ProductLineDelivery> ProductLineDeliveries { get; set; } = new List<ProductLineDelivery>();

    public virtual ICollection<SalesPeriod> SalesPeriods { get; set; } = new List<SalesPeriod>();

    public virtual User UserCreated { get; set; }
}