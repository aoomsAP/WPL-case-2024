﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FCentricProspections.Server.DataModels;

public partial class CustomerCode
{
    public long Id { get; set; }

    public long UserCreatedId { get; set; }

    public DateTime DateCreated { get; set; }

    public byte[] Timestamp { get; set; }

    public bool IsWpsNotified { get; set; }

    public virtual ICollection<CustomerLegalHistory> CustomerLegalHistories { get; set; } = new List<CustomerLegalHistory>();

    public virtual User UserCreated { get; set; }
}