﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FCentricProspections.Server.DataModels;

public partial class ExternalPosJournal
{
    public long Id { get; set; }

    public long ExternalPosId { get; set; }

    public DateTime Date { get; set; }

    public long UserCreatedId { get; set; }

    public DateTime DateCreated { get; set; }

    public byte[] Timestamp { get; set; }

    public bool HasAccountingSession { get; set; }

    public decimal InSubtotal { get; set; }

    public decimal OutSubtotal { get; set; }

    public virtual ExternalPo ExternalPos { get; set; }

    public virtual ICollection<ExternalPosJournalEntry> ExternalPosJournalEntries { get; set; } = new List<ExternalPosJournalEntry>();

    public virtual ICollection<ExternalPosJournalExpense> ExternalPosJournalExpenses { get; set; } = new List<ExternalPosJournalExpense>();

    public virtual ICollection<ExternalPosJournalInvoice> ExternalPosJournalInvoices { get; set; } = new List<ExternalPosJournalInvoice>();

    public virtual ICollection<ExternalPosJournalVoucher> ExternalPosJournalVouchers { get; set; } = new List<ExternalPosJournalVoucher>();

    public virtual User UserCreated { get; set; }
}