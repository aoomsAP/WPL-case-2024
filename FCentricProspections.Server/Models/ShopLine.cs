﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FCentricProspections.Server.Models;

public partial class ShopLine
{
    public long Id { get; set; }

    public long LineId { get; set; }

    public long UserCreatedId { get; set; }

    public DateTime DateCreated { get; set; }

    public byte[] Timestamp { get; set; }

    public long? ShopId { get; set; }

    public virtual Line Line { get; set; }

    public virtual Shop Shop { get; set; }

    public virtual User UserCreated { get; set; }
}