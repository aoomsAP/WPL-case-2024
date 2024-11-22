﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FCentricProspections.Server.DataModels;

public partial class PosSession
{
    public long Id { get; set; }

    public long EmployeeId { get; set; }

    public long PosId { get; set; }

    public decimal StartAmount { get; set; }

    public decimal CalculatedAmount { get; set; }

    public decimal RegisteredAmount { get; set; }

    public string Remark { get; set; }

    public bool IsValidated { get; set; }

    public bool IsClosed { get; set; }

    public DateTime Date { get; set; }

    public DateTime? CloseDate { get; set; }

    public long UserCreatedId { get; set; }

    public DateTime DateCreated { get; set; }

    public byte[] Timestamp { get; set; }

    public long EmployeeClosedId { get; set; }

    public decimal CalculatedStartAmount { get; set; }

    public decimal? BankReservedAmount { get; set; }

    public decimal? ElectronicPaymentsAmount { get; set; }

    public decimal? CalculatedElectronicPaymentsAmount { get; set; }

    public int VoucherCount { get; set; }

    public int CalculatedVoucherCount { get; set; }

    public int FiveHundredCount { get; set; }

    public int TwoHundredCount { get; set; }

    public int OneHundredCount { get; set; }

    public int FiftyCount { get; set; }

    public int TwentyCount { get; set; }

    public int TenCount { get; set; }

    public int FiveCount { get; set; }

    public int TwoCount { get; set; }

    public int OneCount { get; set; }

    public int FiftyCentCount { get; set; }

    public int TwentyCentCount { get; set; }

    public int TenCentCount { get; set; }

    public int FiveCentCount { get; set; }

    public int TwoCentCount { get; set; }

    public int OneCentCount { get; set; }

    public int BankFiveHundredCount { get; set; }

    public int BankTwoHundredCount { get; set; }

    public int BankOneHundredCount { get; set; }

    public int BankFiftyCount { get; set; }

    public int BankTwentyCount { get; set; }

    public int BankTenCount { get; set; }

    public int BankFiveCount { get; set; }

    public int Visitors { get; set; }

    public int BankTwoCount { get; set; }

    public int BankOneCount { get; set; }

    public int BankFiftyCentCount { get; set; }

    public int BankTwentyCentCount { get; set; }

    public int BankTenCentCount { get; set; }

    public int BankFiveCentCount { get; set; }

    public int BankTwoCentCount { get; set; }

    public int BankOneCentCount { get; set; }

    public bool OpeningEdited { get; set; }

    public bool ClosureEdited { get; set; }

    public long? OpeningDifferenceExpenseId { get; set; }

    public long? ClosingDifferenceExpenseId { get; set; }

    public virtual Expense ClosingDifferenceExpense { get; set; }

    public virtual Employee Employee { get; set; }

    public virtual Employee EmployeeClosed { get; set; }

    public virtual Expense OpeningDifferenceExpense { get; set; }

    public virtual Po Pos { get; set; }

    public virtual User UserCreated { get; set; }
}