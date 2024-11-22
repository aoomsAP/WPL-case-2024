﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCentricProspections.Server.DataModels;

public partial class CollectionDelivery
{
    public long Id { get; set; }

    public long UserCreatedId { get; set; }

    public DateTime DateCreated { get; set; }

    public byte[] Timestamp { get; set; }

    public long SalesPeriodId { get; set; }

    public int Qty { get; set; }

    public long? ProductLineDeliveryId { get; set; }

    public long? BrandId { get; set; }

    public long? SupplierId { get; set; }

    public long? SampleDestinationId { get; set; }

    public decimal Amount { get; set; }

    public DateTime? Date { get; set; }

    public string InvoiceNumber { get; set; }

    public int? InvoiceQuantity { get; set; }

    public decimal? InvoiceAmount { get; set; }

    public long? EmployeeId { get; set; }

    public string DocumentNumber { get; set; }

    public int QtyReturn { get; set; }

    public int QtyGarbage { get; set; }

    public int QtySampleSales { get; set; }

    public int NrOfBoxes { get; set; }

    public int HangingPieces { get; set; }

    public long? CollectionDeliveryTypeId { get; set; }

    public long? CollectionDeliveryCategoryId { get; set; }

    public long? CollectionDeliveryWarehouseId { get; set; }

    public bool DirectionIsIn { get; set; }

    public string Remarks { get; set; }

    public int MancoNrOfBoxes { get; set; }

    public int MancoHangingPieces { get; set; }

    public int NrOfBoxesSales { get; set; }

    public int HangingPiecesSales { get; set; }

    public int MancoNrOfBoxesSales { get; set; }

    public int MancoHangingPiecesSales { get; set; }

    public DateTime? DateCompleted { get; set; }

    public long? CollectionDeliveryLocationId { get; set; }

    public long? SalesEmployeeId { get; set; }

    public virtual Brand Brand { get; set; }

    public virtual CollectionDeliveryCategory CollectionDeliveryCategory { get; set; }

    public virtual CollectionDeliveryLocation CollectionDeliveryLocation { get; set; }

    public virtual CollectionDeliveryType CollectionDeliveryType { get; set; }

    public virtual CollectionDeliveryWarehouse CollectionDeliveryWarehouse { get; set; }

    [NotMapped]
    public virtual Employee Employee { get; set; }

    public virtual ProductLineDelivery ProductLineDelivery { get; set; }

    public virtual ICollection<RecomaticsInvoiceCollectionDelivery> RecomaticsInvoiceCollectionDeliveries { get; set; } = new List<RecomaticsInvoiceCollectionDelivery>();

    [NotMapped]
    public virtual Employee SalesEmployee { get; set; }

    public virtual SalesPeriod SalesPeriod { get; set; }

    public virtual SampleDestination SampleDestination { get; set; }

    public virtual Supplier Supplier { get; set; }

    public virtual User UserCreated { get; set; }
}