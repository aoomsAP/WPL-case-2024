﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FCentricProspections.Server.DataModels;

public partial class AgentProductLineDelivery
{
    public long Id { get; set; }

    public long? SalesPeriodId { get; set; }

    public long ProductLineDeliveryId { get; set; }

    public long AgentId { get; set; }

    public long UserCreatedId { get; set; }

    public DateTime DateCreated { get; set; }

    public byte[] Timestamp { get; set; }

    public bool Scheda { get; set; }

    public virtual Agent Agent { get; set; }

    public virtual ProductLineDelivery ProductLineDelivery { get; set; }

    public virtual SalesPeriod SalesPeriod { get; set; }

    public virtual User UserCreated { get; set; }
}