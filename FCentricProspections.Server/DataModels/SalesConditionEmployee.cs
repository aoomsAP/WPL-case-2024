﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FCentricProspections.Server.DataModels;

public partial class SalesConditionEmployee
{
    public long Id { get; set; }

    public long EmployeeId { get; set; }

    public int Priority { get; set; }

    public long SalesConditionId { get; set; }

    public long UserCreatedId { get; set; }

    public DateTime DateCreated { get; set; }

    public byte[] Timestamp { get; set; }

    public long? ShowroomId { get; set; }

    public virtual Employee Employee { get; set; }

    public virtual SalesCondition SalesCondition { get; set; }

    public virtual Showroom Showroom { get; set; }

    public virtual User UserCreated { get; set; }
}