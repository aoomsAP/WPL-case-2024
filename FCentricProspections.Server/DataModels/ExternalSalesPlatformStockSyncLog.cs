﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FCentricProspections.Server.DataModels;

public partial class ExternalSalesPlatformStockSyncLog
{
    public long Id { get; set; }

    public string Barcode { get; set; }

    public int Quantity { get; set; }

    public string Error { get; set; }

    public long UserCreatedId { get; set; }

    public DateTime DateCreated { get; set; }

    public byte[] Timestamp { get; set; }

    public long ExternalSalesPlatformId { get; set; }

    public virtual ExternalSalesPlatform ExternalSalesPlatform { get; set; }

    public virtual User UserCreated { get; set; }
}