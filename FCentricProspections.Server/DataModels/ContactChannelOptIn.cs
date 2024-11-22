﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FCentricProspections.Server.DataModels;

public partial class ContactChannelOptIn
{
    public long Id { get; set; }

    public long ContactChannelId { get; set; }

    public long OptInTypeId { get; set; }

    public long OptInSourceId { get; set; }

    public DateTime OptInDate { get; set; }

    public DateTime? OptOutDate { get; set; }

    public long UserCreatedId { get; set; }

    public DateTime DateCreated { get; set; }

    public byte[] Timestamp { get; set; }

    public Guid? ActionId { get; set; }

    public virtual ContactChannel ContactChannel { get; set; }

    public virtual OptInSource OptInSource { get; set; }

    public virtual OptInType OptInType { get; set; }

    public virtual User UserCreated { get; set; }
}