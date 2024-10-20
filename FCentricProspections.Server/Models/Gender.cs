﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FCentricProspections.Server.Models;

public partial class Gender
{
    public long Id { get; set; }

    public string Name { get; set; }

    public long UserCreatedId { get; set; }

    public DateTime DateCreated { get; set; }

    public byte[] Timestamp { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<ProductLine> ProductLines { get; set; } = new List<ProductLine>();

    public virtual ICollection<ShopGender> ShopGenders { get; set; } = new List<ShopGender>();

    public virtual User UserCreated { get; set; }
}