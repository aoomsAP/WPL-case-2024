﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FCentricProspections.Server.DataModels;

public partial class ProductDeliveryWindow
{
    public long Id { get; set; }

    public long ProductId { get; set; }

    public long DeliveryWindowId { get; set; }

    public long UserCreatedId { get; set; }

    public DateTime DateCreated { get; set; }

    public byte[] Timestamp { get; set; }

    public virtual DeliveryWindow DeliveryWindow { get; set; }

    public virtual Product Product { get; set; }

    public virtual User UserCreated { get; set; }
}