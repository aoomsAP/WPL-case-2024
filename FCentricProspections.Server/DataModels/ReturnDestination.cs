﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FCentricProspections.Server.DataModels;

public partial class ReturnDestination
{
    public long Id { get; set; }

    public string Name { get; set; }

    public long UserCreatedId { get; set; }

    public DateTime DateCreated { get; set; }

    public byte[] Timestamp { get; set; }

    public virtual ICollection<FashionReturnDocument> FashionReturnDocuments { get; set; } = new List<FashionReturnDocument>();

    public virtual User UserCreated { get; set; }
}