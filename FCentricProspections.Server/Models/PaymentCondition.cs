﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FCentricProspections.Server.Models;

public partial class PaymentCondition
{
    public long Id { get; set; }

    public string Code { get; set; }

    public int DueDateCalculator { get; set; }

    public bool Fdi { get; set; }

    public string Name { get; set; }

    public long UserCreatedId { get; set; }

    public DateTime DateCreated { get; set; }

    public byte[] Timestamp { get; set; }

    public string NameFr { get; set; }

    public string NameEn { get; set; }

    public bool IsConsignment { get; set; }

    public virtual ICollection<Country> Countries { get; set; } = new List<Country>();

    public virtual User UserCreated { get; set; }
}