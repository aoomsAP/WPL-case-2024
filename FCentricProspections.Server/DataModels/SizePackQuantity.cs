﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FCentricProspections.Server.DataModels;

public partial class SizePackQuantity
{
    public long Id { get; set; }

    public long SizeId { get; set; }

    public int Quantity { get; set; }

    public long UserCreatedId { get; set; }

    public DateTime DateCreated { get; set; }

    public byte[] Timestamp { get; set; }

    public long? SizePackId { get; set; }

    public virtual Size Size { get; set; }

    public virtual SizePack SizePack { get; set; }

    public virtual User UserCreated { get; set; }
}