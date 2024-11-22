﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FCentricProspections.Server.DataModels;

public partial class PosDocumentLine
{
    public long Id { get; set; }

    public long EmployeeId { get; set; }

    public long? ModificationTypeId { get; set; }

    public bool CheckedOutByCustomer { get; set; }

    public DateTime? ModificationDueDate { get; set; }

    public string PriceChangedReason { get; set; }

    public string Description { get; set; }

    public bool HasModifiedPrice { get; set; }

    public decimal? ModificationPrice { get; set; }

    public string DiscountReason { get; set; }

    public string ModificationDescription { get; set; }

    public long? DiscountCampaignLineId { get; set; }

    public long? PosDiscountReasonId { get; set; }

    public bool IsSample { get; set; }

    public virtual DiscountCampaignLine DiscountCampaignLine { get; set; }

    public virtual Employee Employee { get; set; }

    public virtual DocumentLine IdNavigation { get; set; }

    public virtual ModificationType ModificationType { get; set; }

    public virtual PosDiscountReason PosDiscountReason { get; set; }
}