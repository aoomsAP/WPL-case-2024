﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FCentricProspections.Server.DataModels;

public partial class ShopDelivery
{
    public long Id { get; set; }

    public long? ShopId { get; set; }

    public long? ShopDeliveryReferenceId { get; set; }

    public long ProductLineDeliveryId { get; set; }

    public long SalesPeriodId { get; set; }

    public long ShopDeliveryStateId { get; set; }

    public long ShopDeliveryTypeId { get; set; }

    public long ShopDeliveryOriginId { get; set; }

    public decimal? BudgetAmount { get; set; }

    public int? BudgetQuantity { get; set; }

    public decimal? OrderAmount { get; set; }

    public int? OrderQuantity { get; set; }

    public string Remarks { get; set; }

    public long? CountryId { get; set; }

    public long? Order { get; set; }

    public long UserCreatedId { get; set; }

    public DateTime DateCreated { get; set; }

    public byte[] Timestamp { get; set; }

    public long? StockLocationId { get; set; }

    public int? BonusBudget { get; set; }

    public bool IgnoreBonusBudget { get; set; }

    public bool CanSwap { get; set; }

    public decimal? MarginPercentage { get; set; }

    public long? ShowroomId { get; set; }

    public virtual Country Country { get; set; }

    public virtual ICollection<ShopDelivery> InverseShopDeliveryReference { get; set; } = new List<ShopDelivery>();

    public virtual ProductLineDelivery ProductLineDelivery { get; set; }

    public virtual SalesPeriod SalesPeriod { get; set; }

    public virtual Shop Shop { get; set; }

    public virtual ShopDelivery ShopDeliveryReference { get; set; }

    public virtual User UserCreated { get; set; }
}