﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FCentricProspections.Server.DataModels;

public partial class App
{
    public long Id { get; set; }

    public Guid Key { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}