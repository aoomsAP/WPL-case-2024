﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FCentricProspections.Server.DataModels;

public partial class OptInSource
{
    public long Id { get; set; }

    public string Name { get; set; }

    public long UserCreatedId { get; set; }

    public DateTime DateCreated { get; set; }

    public byte[] Timestamp { get; set; }

    public virtual ICollection<ContactChannelOptIn> ContactChannelOptIns { get; set; } = new List<ContactChannelOptIn>();

    public virtual User UserCreated { get; set; }
}