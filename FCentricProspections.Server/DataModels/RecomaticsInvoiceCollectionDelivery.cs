﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FCentricProspections.Server.DataModels;

public partial class RecomaticsInvoiceCollectionDelivery
{
    public long Id { get; set; }

    public long RecomaticsInvoiceId { get; set; }

    public long CollectionDeliveryId { get; set; }

    public long UserCreatedId { get; set; }

    public DateTime DateCreated { get; set; }

    public byte[] Timestamp { get; set; }

    public virtual CollectionDelivery CollectionDelivery { get; set; }

    public virtual RecomaticsInvoice RecomaticsInvoice { get; set; }

    public virtual User UserCreated { get; set; }
}