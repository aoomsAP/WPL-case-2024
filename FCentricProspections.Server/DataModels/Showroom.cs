﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FCentricProspections.Server.DataModels;

public partial class Showroom
{
    public long Id { get; set; }

    public string Code { get; set; }

    public long? ContactId { get; set; }

    public decimal? Surface { get; set; }

    public int? Floor { get; set; }

    public string Name { get; set; }

    public long UserCreatedId { get; set; }

    public DateTime DateCreated { get; set; }

    public byte[] Timestamp { get; set; }

    public bool IsDedicated { get; set; }

    public virtual Contact Contact { get; set; }

    public virtual ICollection<SalesConditionEmployee> SalesConditionEmployees { get; set; } = new List<SalesConditionEmployee>();

    public virtual ICollection<SalesConditionShowroom> SalesConditionShowrooms { get; set; } = new List<SalesConditionShowroom>();

    public virtual ICollection<ShopDelivery> ShopDeliveries { get; set; } = new List<ShopDelivery>();

    public virtual ICollection<ShowroomAppointment> ShowroomAppointments { get; set; } = new List<ShowroomAppointment>();

    public virtual User UserCreated { get; set; }
}