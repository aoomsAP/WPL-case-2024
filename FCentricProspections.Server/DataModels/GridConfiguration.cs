﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FCentricProspections.Server.DataModels;

public partial class GridConfiguration
{
    public long Id { get; set; }

    public byte[] Configuration { get; set; }

    public string Name { get; set; }

    public long UserCreatedId { get; set; }

    public DateTime DateCreated { get; set; }

    public byte[] Timestamp { get; set; }

    public string Alias { get; set; }

    public long? GridConfigurationGroupId { get; set; }

    public virtual GridConfigurationGroup GridConfigurationGroup { get; set; }

    public virtual User UserCreated { get; set; }
}