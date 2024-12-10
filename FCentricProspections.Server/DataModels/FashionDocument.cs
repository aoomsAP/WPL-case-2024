#nullable disable
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace FCentricProspections.Server.DataModels;

public partial class FashionDocument
{
    public long Id { get; set; }

    public long SalesPeriodId { get; set; }

    public long CustomerLegalHistoryId { get; set; }

    public long DeliveryAddressId { get; set; }

    public long? DeliveryMethodId { get; set; }

    public long PaymentConditionId { get; set; }

    public long AccountingCodeId { get; set; }

    public long? FileImportLogId { get; set; }

    public long? PosId { get; set; }

    public long? PublicationId { get; set; }

    public long? LoyaltyVoucherBarcodeId { get; set; }

    public long? PosTicketCancellationReasonId { get; set; }

    public string PosTicketCancellationReasonDescription { get; set; }

    public string BoxNumber { get; set; }

    public bool EmailInvoicingTeam { get; set; }

    public string TransferHash { get; set; }

    public long? SourceShopId { get; set; }

    public long? DestinationShopId { get; set; }


    public virtual Contact DeliveryAddress { get; set; }


    public virtual Shop DestinationShop { get; set; }

    public virtual ICollection<FashionDocumentShop> FashionDocumentShops { get; set; } = new List<FashionDocumentShop>();
    
    public virtual SalesPeriod SalesPeriod { get; set; }

    public virtual Shop SourceShop { get; set; }
}