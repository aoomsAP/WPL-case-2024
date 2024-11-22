﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FCentricProspections.Server.DataModels;

public partial class Region
{
    public long Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public long UserCreatedId { get; set; }

    public DateTime DateCreated { get; set; }

    public byte[] Timestamp { get; set; }

    public bool IsSalesPeriodPriceRegion { get; set; }

    public virtual ICollection<AgentRegion> AgentRegions { get; set; } = new List<AgentRegion>();

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual ICollection<CityPriceRegion> CityPriceRegions { get; set; } = new List<CityPriceRegion>();

    public virtual ICollection<FashionProductSizeRegion> FashionProductSizeRegions { get; set; } = new List<FashionProductSizeRegion>();

    public virtual ICollection<SupplierMarkup> SupplierMarkups { get; set; } = new List<SupplierMarkup>();

    public virtual User UserCreated { get; set; }
}