using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FCentricProspections.Server.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "AccountingSessionNumberSequence",
                startValue: 1514L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "AllocationNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "B2CLinkedNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "B2CReturnNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "B2CUploadNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "BackOrderNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "BatchNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "BleckmannInventoryNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "BlockedDeliveryNumberSequence",
                startValue: 10893L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "BorrowNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "brandMIRACLESEanCodeSequence",
                startValue: 540084680000L,
                minValue: 540084680000L,
                maxValue: 540084690000L);

            migrationBuilder.CreateSequence(
                name: "brandSVNTYEanCodeSequence",
                startValue: 540084601712L,
                minValue: 540084000000L);

            migrationBuilder.CreateSequence(
                name: "brandWildwonEanCodeSequence",
                startValue: 540084690228L,
                minValue: 540084690000L,
                maxValue: 540084700000L);

            migrationBuilder.CreateSequence(
                name: "BulkConfirmationNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "BulkDeliveryNumberSequence",
                startValue: 81L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "BulkOrderNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "BulkReturnIncomingNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "BulkReturnPacklistNumberSequence",
                startValue: 170L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "CanceledNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "ColorSkuSequence",
                startValue: 200000L);

            migrationBuilder.CreateSequence(
                name: "ConfirmationNumberSequence",
                startValue: 42661L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "ConsignmentNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "DebitCreditNoteNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "DebitNoteNumberSequence",
                startValue: 55L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "DeliveryNoteNumberSequence",
                startValue: 55122L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "DraftNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "EanCodeSequence",
                startValue: 8382416L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "FcStoreConfirmationNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "FcStoreDeliveryNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "FcStoreReceptionNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "IncomingBulkDeliveryNumberSequence",
                startValue: 41L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "IncomingDeliveryNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "IncomingOccasionalNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "IncomingPackingListNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InventoryNumberSequence",
                startValue: 1199L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201500",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201501",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201502",
                startValue: 9123L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201503",
                startValue: 46L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201504",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201505",
                startValue: 286L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201506",
                startValue: 317L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201507",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201508",
                startValue: 38L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201509",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201510",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201511",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201512",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201513",
                startValue: 7L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201514",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201515",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201516",
                startValue: 8L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201517",
                startValue: 43L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201518",
                startValue: 129L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201519",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201520",
                startValue: 161L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201521",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201522",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201523",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201524",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201525",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201526",
                startValue: 5L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201527",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201528",
                startValue: 2L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201529",
                startValue: 196L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201530",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201531",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201532",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201533",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201534",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201535",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201536",
                startValue: 2L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201537",
                startValue: 2L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201538",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201539",
                startValue: 268L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201540",
                startValue: 451L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201541",
                startValue: 385L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201542",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201543",
                startValue: 8L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201544",
                startValue: 28L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201545",
                startValue: 251L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201546",
                startValue: 2L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201547",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201548",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201549",
                startValue: 12L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201550",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201551",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201552",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201553",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201554",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201555",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201556",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201557",
                startValue: 3L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201558",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201559",
                startValue: 386L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201560",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201561",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201562",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201563",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201564",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201565",
                startValue: 26L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201566",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201567",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201568",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201569",
                startValue: 17L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201570",
                startValue: 123L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201571",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201572",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201573",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201574",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201575",
                startValue: 82L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201576",
                startValue: 223L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201577",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201578",
                startValue: 3L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201579",
                startValue: 58L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201580",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201581",
                startValue: 437L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201582",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201583",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201584",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201585",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201586",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201587",
                startValue: 33L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201588",
                startValue: 408L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201589",
                startValue: 32L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201590",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201591",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201592",
                startValue: 2L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201595",
                startValue: 10757L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201597",
                startValue: 313L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201599",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201600",
                startValue: 32L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201602",
                startValue: 7478L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201605",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201606",
                startValue: 433L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201608",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201609",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201610",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201611",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201614",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201615",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201616",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201617",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201618",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201620",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201622",
                startValue: 9L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201624",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201625",
                startValue: 9L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201627",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201629",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201630",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201632",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201638",
                startValue: 10L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201639",
                startValue: 18L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201640",
                startValue: 703L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201641",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201642",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201645",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201647",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201648",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201650",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201654",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201656",
                startValue: 12L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201659",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201661",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201662",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201664",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201665",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201667",
                startValue: 1139L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201668",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201669",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201670",
                startValue: 11L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201672",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201675",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201676",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201679",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201681",
                startValue: 23L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201688",
                startValue: 618L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201692",
                startValue: 7L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201695",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201697",
                startValue: 409L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201700",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201702",
                startValue: 6653L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201706",
                startValue: 2771L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201710",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201711",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201714",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201720",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201722",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201724",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201727",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201729",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201730",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201734",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201738",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201739",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201740",
                startValue: 1010L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201741",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201742",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201745",
                startValue: 28L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201748",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201756",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201759",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201761",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201764",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201765",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201767",
                startValue: 1032L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201768",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201770",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201772",
                startValue: 181L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201776",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201779",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201781",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201784",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201788",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201792",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201793",
                startValue: 3L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201795",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201797",
                startValue: 1712L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201799",
                startValue: 36L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201800",
                startValue: 290L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2018000",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201802",
                startValue: 5871L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201803",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201806",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201809",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201810",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201811",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201814",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201815",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201817",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201820",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201821",
                startValue: 137L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201822",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201823",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201826",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201827",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201829",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201830",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2018300",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2018301",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2018302",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201831",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201835",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201836",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201837",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201838",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201839",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201840",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201842",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201843",
                startValue: 5L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201844",
                startValue: 8L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201845",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2018501",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201852",
                startValue: 3L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201854",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201856",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201859",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201867",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201868",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201871",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201876",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201879",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201881",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201884",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201886",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201888",
                startValue: 228L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201892",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201893",
                startValue: 12L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201897",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201899",
                startValue: 31L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201900",
                startValue: 123L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence201903",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019301",
                startValue: 5693L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019302",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019402",
                startValue: 1393L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019403",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019405",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019409",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019413",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019414",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019415",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019416",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019419",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019420",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019421",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019422",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019423",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019424",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019425",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019426",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019428",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019429",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019430",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019431",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019433",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019435",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019438",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019439",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019440",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019441",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019443",
                startValue: 5L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019444",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019446",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019454",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019458",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019459",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019467",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019468",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019471",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019476",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019481",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019483",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019484",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019488",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019497",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019499",
                startValue: 16L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019501",
                startValue: 1695L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019520",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2019530",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence202000",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence202010",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020301",
                startValue: 6271L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020302",
                startValue: 5L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020400",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020402",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020403",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020405",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020409",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020413",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020414",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020415",
                startValue: 418L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020420",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020422",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020425",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020426",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020428",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020429",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020430",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020431",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020433",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020434",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020436",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020439",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020440",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020441",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020443",
                startValue: 22L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020444",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020458",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020471",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020476",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020484",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020488",
                startValue: 628L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020497",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020499",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020501",
                startValue: 1697L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020520",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020530",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2020601",
                startValue: 875L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence202100",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence202110",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021301",
                startValue: 317L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021403",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021404",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021408",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021412",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021414",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021415",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021416",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021420",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021425",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021426",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021428",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021429",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021430",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021433",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021434",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021436",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021443",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021444",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021452",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021458",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021462",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021484",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021488",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021497",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021499",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021501",
                startValue: 40L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence202151",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021520",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021530",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021601",
                startValue: 56L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021701",
                startValue: 40L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2021801",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence202200",
                startValue: 56L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022301",
                startValue: 3902L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022403",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022404",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022405",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022407",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022408",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022410",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022412",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022413",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022415",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022416",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022419",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022420",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022426",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022429",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022430",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022434",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022443",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022444",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022452",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022458",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022462",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022465",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022475",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022476",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022484",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022488",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022497",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022499",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022501",
                startValue: 191L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022520",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022530",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022601",
                startValue: 1553L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022701",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2022801",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence202300",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence202310",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023301",
                startValue: 3749L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023403",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023404",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023407",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023408",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023410",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023413",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023415",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023416",
                startValue: 607L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023417",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023420",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023426",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023427",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023429",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023432",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023434",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023441",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023443",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023444",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023458",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023462",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023465",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023475",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023484",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023488",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023499",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023501",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023520",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023530",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023601",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023701",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2023801",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence202400",
                startValue: 121L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024301",
                startValue: 486L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024303",
                startValue: 73L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024307",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024403",
                startValue: 985L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024407",
                startValue: 181L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024408",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024414",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024415",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024416",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024417",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024420",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024426",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024427",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024429",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024432",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024435",
                startValue: 30L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024437",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024441",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024443",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024445",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024458",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024465",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024475",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024484",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024488",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024499",
                startValue: 2L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024501",
                startValue: 459L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024520",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024530",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024601",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "InvoiceNumberSequence2024801",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "MancoNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "MiscInvoiceNumberSequence",
                startValue: 80750L);

            migrationBuilder.CreateSequence(
                name: "MiscProformaNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "OccasionalStockNumberSequence",
                startValue: 317L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "OrderAtSupplierNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "OrderNumberSequence",
                startValue: 6L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "PackingListNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "PosCancelledTicketNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "PosInvoiceNumberSequence2016492",
                startValue: 3614L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "PosInvoiceNumberSequence2017492",
                startValue: 1378L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "PosInvoiceNumberSequence2018492",
                startValue: 2459L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "PosInvoiceNumberSequence2019492",
                startValue: 1789L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "PosInvoiceNumberSequence2020492",
                startValue: 105L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "PosInvoiceNumberSequence2021492",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "PosInvoiceNumberSequence2022492",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "PosInvoiceNumberSequence2023492",
                startValue: 789L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "PosInvoiceNumberSequence2024492",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "PosITSRequestIdNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "PosNumberSequence",
                startValue: 7348L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "PosParkedTicketNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "PosReceiverNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "PosSenderNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "PosTransportNumberSequence",
                startValue: 20L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "ReorderNumberSequence",
                startValue: 2239L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "ReturnNumberSequence",
                startValue: 34447L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "SampleLoanNumberSequence",
                startValue: 888L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "SampleSelectionNumberSequence",
                startValue: 952L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "SampleToFC70NumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "SampleToPressNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "SampleToReturn",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "SampleToReturnNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "ShoppingBasketNumberSequence",
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "StockAdjustmentNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "StockDeliveryNumberSequence",
                startValue: 362L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "StockOrderNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "StockReceiveTransferNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "StockSendTransferNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "SvntyWebOrderNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "SwapBasketNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "SwapNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "TheftNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "UndefinedStockNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateSequence(
                name: "WebOrderNumberSequence",
                startValue: 0L,
                minValue: 0L);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Blocked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgeCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.AgeCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.AgeCategories_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BlockedTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.BlockedTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.BlockedTypes_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EAN = table.Column<long>(type: "bigint", nullable: true),
                    MinBulkDeliveryPercentage = table.Column<double>(type: "float", nullable: true),
                    DeliveryFeePercentage = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Brands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.Brands_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CommercialLocations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.CommercialLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.CommercialLocations_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompetitorBrands",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.CompetitorBrands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.CompetitorBrands_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContactTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsLocation = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ContactTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.ContactTypes_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Sign = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Currencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.Currencies_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomerCodes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    IsWpsNotified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.CustomerCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.CustomerCodes_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomerTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    ExludeVat = table.Column<bool>(type: "bit", nullable: false),
                    HasToOptIn = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.CustomerTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.CustomerTypes_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    TelNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HideForAgenda = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    RecurringAppointment_Id = table.Column<long>(type: "bigint", nullable: true),
                    Pin = table.Column<int>(type: "int", nullable: false),
                    AgentId = table.Column<long>(type: "bigint", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.Employees_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.Employees_dbo.Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Genders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.Genders_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    DocumentSupported = table.Column<bool>(type: "bit", nullable: false),
                    DocumentDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Languages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.Languages_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LegalForms",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.LegalForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.LegalForms_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lines",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Lines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.Lines_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PaymentConditions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DueDateCalculator = table.Column<int>(type: "int", nullable: false),
                    Fdi = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    NameFr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsConsignment = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PaymentConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.PaymentConditions_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    IsSalesPeriodPriceRegion = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.Regions_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SalesPeriodTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    MainDeliveryStartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    MainDeliveryStopDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    MainAcceptDeliveryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PreDeliveryStartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PreDeliveryStopDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PreAcceptDeliveryDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.SalesPeriodTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.SalesPeriodTypes_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SegmentTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.SegmentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.SegmentTypes_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShopDeliveryOrigins",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ShopDeliveryOrigins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.ShopDeliveryOrigins_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShopDeliveryStates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    IsCustomer = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ShopDeliveryStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.ShopDeliveryStates_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShopDeliveryTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IsCustomer = table.Column<bool>(type: "bit", nullable: false),
                    ShowOnConfirmation = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ShopDeliveryTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.ShopDeliveryTypes_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShopTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ShopTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.ShopTypes_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Spancos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Spancos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.Spancos_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VatTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsTaxLevy = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.VatTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.VatTypes_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SalesPeriods",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BeginDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    TransportCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransportCostLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InflationPercentage = table.Column<int>(type: "int", nullable: false),
                    SalesPeriodTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    ShowInWebshop = table.Column<bool>(type: "bit", nullable: false),
                    DeliveryBeginDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeliveryEndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    WpsCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WpsYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LendingPeriodEndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ShopifySales = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.SalesPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.SalesPeriods_dbo.SalesPeriodTypes_SalesPeriodTypeId",
                        column: x => x.SalesPeriodTypeId,
                        principalTable: "SalesPeriodTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.SalesPeriods_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductLines",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BrandId = table.Column<long>(type: "bigint", nullable: false),
                    LineId = table.Column<long>(type: "bigint", nullable: false),
                    GenderId = table.Column<long>(type: "bigint", nullable: false),
                    AgeCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    SegmentTypeId = table.Column<long>(type: "bigint", nullable: false),
                    AveragePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RadiusExclusivity = table.Column<int>(type: "int", nullable: false),
                    FashionLevel = table.Column<int>(type: "int", nullable: false),
                    IsCompetitor = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ProductLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.ProductLines_dbo.AgeCategories_AgeCategoryId",
                        column: x => x.AgeCategoryId,
                        principalTable: "AgeCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.ProductLines_dbo.Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.ProductLines_dbo.Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.ProductLines_dbo.Lines_LineId",
                        column: x => x.LineId,
                        principalTable: "Lines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.ProductLines_dbo.SegmentTypes_SegmentTypeId",
                        column: x => x.SegmentTypeId,
                        principalTable: "SegmentTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.ProductLines_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: false),
                    PaymentConditionId = table.Column<long>(type: "bigint", nullable: false),
                    VatTypeId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.Countries_dbo.Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.Countries_dbo.PaymentConditions_PaymentConditionId",
                        column: x => x.PaymentConditionId,
                        principalTable: "PaymentConditions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.Countries_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.Countries_dbo.VatTypes_VatTypeId",
                        column: x => x.VatTypeId,
                        principalTable: "VatTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductLineDeliveries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SalesPeriodTypeId = table.Column<long>(type: "bigint", nullable: true),
                    SalesTime = table.Column<int>(type: "int", nullable: false),
                    IsInUse = table.Column<bool>(type: "bit", nullable: false),
                    ProductLineId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    SupplierReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductLineDeliveryRelatedId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ProductLineDeliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.ProductLineDeliveries_dbo.ProductLineDeliveries_ProductLineDeliveryRelatedId",
                        column: x => x.ProductLineDeliveryRelatedId,
                        principalTable: "ProductLineDeliveries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.ProductLineDeliveries_dbo.ProductLines_ProductLineId",
                        column: x => x.ProductLineId,
                        principalTable: "ProductLines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.ProductLineDeliveries_dbo.SalesPeriodTypes_SalesPeriodTypeId",
                        column: x => x.SalesPeriodTypeId,
                        principalTable: "SalesPeriodTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.ProductLineDeliveries_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Provinces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.Provinces_dbo.Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.Provinces_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostalCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    ProvinceId = table.Column<long>(type: "bigint", nullable: true),
                    RegionId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    SearchName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.Cities_dbo.Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.Cities_dbo.Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.Cities_dbo.Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.Cities_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Attention = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Street1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Street2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CityId = table.Column<long>(type: "bigint", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.Addresses_dbo.Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.Addresses_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveryMethodId = table.Column<long>(type: "bigint", nullable: true),
                    UpfrontPaymentId = table.Column<long>(type: "bigint", nullable: true),
                    PaymentConditionId = table.Column<long>(type: "bigint", nullable: true),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: true),
                    BlockedTypeId = table.Column<long>(type: "bigint", nullable: true),
                    BlockedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    BlockedReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Iban = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Bic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BankCityId = table.Column<long>(type: "bigint", nullable: true),
                    VatTypeId = table.Column<long>(type: "bigint", nullable: true),
                    KeyAccountManagerId = table.Column<long>(type: "bigint", nullable: true),
                    DeliveryLocationTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    IsKeyAccount = table.Column<bool>(type: "bit", nullable: false),
                    SearchName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsPosCustomer = table.Column<bool>(type: "bit", nullable: false),
                    Top50 = table.Column<bool>(type: "bit", nullable: false),
                    Dd = table.Column<bool>(type: "bit", nullable: false),
                    CustomerTypeId = table.Column<long>(type: "bigint", nullable: true),
                    AttendedCollectionSale = table.Column<int>(type: "int", nullable: false),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    CollectionSaleCustomerCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaximumBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IgnoreAutomaticOverrule = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AgentId = table.Column<long>(type: "bigint", nullable: true),
                    CanAlwaysSwap = table.Column<bool>(type: "bit", nullable: false),
                    GlobalLocationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgreeToUseTheirData = table.Column<bool>(type: "bit", nullable: false),
                    CustomerLoyaltyId = table.Column<long>(type: "bigint", nullable: true),
                    AnniversaryDay = table.Column<DateTime>(type: "datetime", nullable: true),
                    AccountingCodeId = table.Column<long>(type: "bigint", nullable: true),
                    IsKeyClient = table.Column<bool>(type: "bit", nullable: false),
                    GenderId = table.Column<long>(type: "bigint", nullable: true),
                    MiscAccountingCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime", nullable: true),
                    IgnoreInReporting = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.Customers_dbo.BlockedTypes_BlockedTypeId",
                        column: x => x.BlockedTypeId,
                        principalTable: "BlockedTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.Customers_dbo.Cities_BankCityId",
                        column: x => x.BankCityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.Customers_dbo.Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.Customers_dbo.CustomerTypes_CustomerTypeId",
                        column: x => x.CustomerTypeId,
                        principalTable: "CustomerTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.Customers_dbo.Employees_KeyAccountManagerId",
                        column: x => x.KeyAccountManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.Customers_dbo.Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.Customers_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<long>(type: "bigint", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsSupplierContact = table.Column<bool>(type: "bit", nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    WebUserId = table.Column<long>(type: "bigint", nullable: true),
                    SearchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SearchName2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.Contacts_dbo.Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.Contacts_dbo.Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.Contacts_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomerLegalHistories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerCodeId = table.Column<long>(type: "bigint", nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    VatNr = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    VatCheckState = table.Column<int>(type: "int", nullable: false),
                    VatCheckDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kvk = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    LegalContactId = table.Column<long>(type: "bigint", nullable: false),
                    RequestIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalFormId = table.Column<long>(type: "bigint", nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    VatNrSearch = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.CustomerLegalHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.CustomerLegalHistories_dbo.Contacts_LegalContactId",
                        column: x => x.LegalContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.CustomerLegalHistories_dbo.CustomerCodes_CustomerCodeId",
                        column: x => x.CustomerCodeId,
                        principalTable: "CustomerCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.CustomerLegalHistories_dbo.Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.CustomerLegalHistories_dbo.LegalForms_LegalFormId",
                        column: x => x.LegalFormId,
                        principalTable: "LegalForms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.CustomerLegalHistories_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpeningDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Area = table.Column<int>(type: "int", nullable: true),
                    SalesPeople = table.Column<int>(type: "int", nullable: true),
                    DisplayWindows = table.Column<int>(type: "int", nullable: true),
                    Floors = table.Column<int>(type: "int", nullable: true),
                    ShopTypeId = table.Column<long>(type: "bigint", nullable: true),
                    SpancoId = table.Column<long>(type: "bigint", nullable: true),
                    ContactId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    SearchName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsParallelSales = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Shops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.Shops_dbo.Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.Shops_dbo.ShopTypes_ShopTypeId",
                        column: x => x.ShopTypeId,
                        principalTable: "ShopTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.Shops_dbo.Spancos_SpancoId",
                        column: x => x.SpancoId,
                        principalTable: "Spancos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.Shops_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomerShops",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.CustomerShops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.CustomerShops_dbo.Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.CustomerShops_dbo.Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.CustomerShops_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Prospections",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShopId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prospections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.Prospections_dbo.Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShopCommercialLocations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommercialLocationId = table.Column<long>(type: "bigint", nullable: false),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Shop_Id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ShopCommercialLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.ShopCommercialLocations_dbo.CommercialLocations_CommercialLocationId",
                        column: x => x.CommercialLocationId,
                        principalTable: "CommercialLocations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.ShopCommercialLocations_dbo.Shops_Shop_Id",
                        column: x => x.Shop_Id,
                        principalTable: "Shops",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.ShopCommercialLocations_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShopCompetitorBrands",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompetitorBrandId = table.Column<long>(type: "bigint", nullable: false),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Shop_Id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ShopCompetitorBrands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.ShopCompetitorBrands_dbo.CompetitorBrands_CompetitorBrandId",
                        column: x => x.CompetitorBrandId,
                        principalTable: "CompetitorBrands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.ShopCompetitorBrands_dbo.Shops_Shop_Id",
                        column: x => x.Shop_Id,
                        principalTable: "Shops",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.ShopCompetitorBrands_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShopCompetitorProductLines",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductLineId = table.Column<long>(type: "bigint", nullable: false),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Shop_Id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ShopCompetitorProductLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.ShopCompetitorProductLines_dbo.ProductLines_ProductLineId",
                        column: x => x.ProductLineId,
                        principalTable: "ProductLines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.ShopCompetitorProductLines_dbo.Shops_Shop_Id",
                        column: x => x.Shop_Id,
                        principalTable: "Shops",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.ShopCompetitorProductLines_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShopContacts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactId = table.Column<long>(type: "bigint", nullable: false),
                    ContactTypeId = table.Column<long>(type: "bigint", nullable: false),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Shop_Id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ShopContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.ShopContacts_dbo.ContactTypes_ContactTypeId",
                        column: x => x.ContactTypeId,
                        principalTable: "ContactTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.ShopContacts_dbo.Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.ShopContacts_dbo.Shops_Shop_Id",
                        column: x => x.Shop_Id,
                        principalTable: "Shops",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.ShopContacts_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShopDeliveries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopId = table.Column<long>(type: "bigint", nullable: true),
                    ShopDeliveryReferenceId = table.Column<long>(type: "bigint", nullable: true),
                    ProductLineDeliveryId = table.Column<long>(type: "bigint", nullable: false),
                    SalesPeriodId = table.Column<long>(type: "bigint", nullable: false),
                    ShopDeliveryStateId = table.Column<long>(type: "bigint", nullable: false),
                    ShopDeliveryTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ShopDeliveryOriginId = table.Column<long>(type: "bigint", nullable: false),
                    BudgetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BudgetQuantity = table.Column<int>(type: "int", nullable: true),
                    OrderAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OrderQuantity = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<long>(type: "bigint", nullable: true),
                    Order = table.Column<long>(type: "bigint", nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    StockLocationId = table.Column<long>(type: "bigint", nullable: true),
                    BonusBudget = table.Column<int>(type: "int", nullable: true),
                    IgnoreBonusBudget = table.Column<bool>(type: "bit", nullable: false),
                    CanSwap = table.Column<bool>(type: "bit", nullable: false),
                    MarginPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ShowroomId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ShopDeliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.ShopDeliveries_dbo.Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.ShopDeliveries_dbo.ProductLineDeliveries_ProductLineDeliveryId",
                        column: x => x.ProductLineDeliveryId,
                        principalTable: "ProductLineDeliveries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.ShopDeliveries_dbo.SalesPeriods_SalesPeriodId",
                        column: x => x.SalesPeriodId,
                        principalTable: "SalesPeriods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.ShopDeliveries_dbo.ShopDeliveries_ShopDeliveryReferenceId",
                        column: x => x.ShopDeliveryReferenceId,
                        principalTable: "ShopDeliveries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.ShopDeliveries_dbo.ShopDeliveryOrigins_ShopDeliveryOriginId",
                        column: x => x.ShopDeliveryOriginId,
                        principalTable: "ShopDeliveryOrigins",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.ShopDeliveries_dbo.ShopDeliveryStates_ShopDeliveryStateId",
                        column: x => x.ShopDeliveryStateId,
                        principalTable: "ShopDeliveryStates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.ShopDeliveries_dbo.ShopDeliveryTypes_ShopDeliveryTypeId",
                        column: x => x.ShopDeliveryTypeId,
                        principalTable: "ShopDeliveryTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.ShopDeliveries_dbo.Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.ShopDeliveries_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShopGenders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderId = table.Column<long>(type: "bigint", nullable: false),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Shop_Id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ShopGenders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.ShopGenders_dbo.Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.ShopGenders_dbo.Shops_Shop_Id",
                        column: x => x.Shop_Id,
                        principalTable: "Shops",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.ShopGenders_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShopLines",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineId = table.Column<long>(type: "bigint", nullable: false),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Shop_Id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.ShopLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.ShopLines_dbo.Lines_LineId",
                        column: x => x.LineId,
                        principalTable: "Lines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.ShopLines_dbo.Shops_Shop_Id",
                        column: x => x.Shop_Id,
                        principalTable: "Shops",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dbo.ShopLines_dbo.Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserCreatedId",
                table: "Addresses",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_CityId",
                table: "Addresses",
                column: "CityId")
                .Annotation("SqlServer:FillFactor", 95);

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "AgeCategories",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_UserCreatedId",
                table: "AgeCategories",
                column: "UserCreatedId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "BlockedTypes",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_UserCreatedId",
                table: "BlockedTypes",
                column: "UserCreatedId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Brands_UserCreatedId",
                table: "Brands",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "Brands",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId",
                table: "Cities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_RegionId",
                table: "Cities",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_UserCreatedId",
                table: "Cities",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryId",
                table: "Cities",
                column: "CountryId")
                .Annotation("SqlServer:FillFactor", 95);

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "Cities",
                column: "Name")
                .Annotation("SqlServer:FillFactor", 95);

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "CommercialLocations",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_UserCreatedId",
                table: "CommercialLocations",
                column: "UserCreatedId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "CompetitorBrands",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserCreatedId",
                table: "CompetitorBrands",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressId",
                table: "Contacts",
                column: "AddressId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_LanguageId",
                table: "Contacts",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserCreatedId",
                table: "Contacts",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_WebUserId",
                table: "Contacts",
                column: "WebUserId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_dbo_ContactTypes_Order",
                table: "ContactTypes",
                column: "Order")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "ContactTypes",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_UserCreatedId",
                table: "ContactTypes",
                column: "UserCreatedId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Code",
                table: "Countries",
                column: "Code",
                unique: true)
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CurrencyId",
                table: "Countries",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "Countries",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentConditionId",
                table: "Countries",
                column: "PaymentConditionId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_UserCreatedId",
                table: "Countries",
                column: "UserCreatedId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_VatTypeId",
                table: "Countries",
                column: "VatTypeId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Code",
                table: "Currencies",
                column: "Code",
                unique: true)
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "Currencies",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_UserCreatedId",
                table: "Currencies",
                column: "UserCreatedId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCodes_UserCreatedId",
                table: "CustomerCodes",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCodeId",
                table: "CustomerLegalHistories",
                column: "CustomerCodeId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerId",
                table: "CustomerLegalHistories",
                column: "CustomerId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerLegalHistories_LegalFormId",
                table: "CustomerLegalHistories",
                column: "LegalFormId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerLegalHistories_UserCreatedId",
                table: "CustomerLegalHistories",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalContactId",
                table: "CustomerLegalHistories",
                column: "LegalContactId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_BlockedTypeId",
                table: "Customers",
                column: "BlockedTypeId")
                .Annotation("SqlServer:FillFactor", 95);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BankCityId",
                table: "Customers",
                column: "BankCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CurrencyId",
                table: "Customers",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_KeyAccountManagerId",
                table: "Customers",
                column: "KeyAccountManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserCreatedId",
                table: "Customers",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTypeId",
                table: "Customers",
                column: "CustomerTypeId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_GenderId",
                table: "Customers",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_VatTypeId",
                table: "Customers",
                column: "VatTypeId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "Missing_IXNC_Customers_CustomerTypeId_IsDeleted_5DF16",
                table: "Customers",
                columns: new[] { "CustomerTypeId", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "Missing_IXNC_Customers_CustomerTypeId_IsDeleted_9691B",
                table: "Customers",
                columns: new[] { "CustomerTypeId", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "Missing_IXNC_Customers_CustomerTypeId_IsDeleted_B75BA",
                table: "Customers",
                columns: new[] { "CustomerTypeId", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerId",
                table: "CustomerShops",
                column: "CustomerId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerShops_UserCreatedId",
                table: "CustomerShops",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_dbo_CustomerShops_covering",
                table: "CustomerShops",
                columns: new[] { "ShopId", "CustomerId" })
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_ShopId",
                table: "CustomerShops",
                column: "ShopId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_UserCreatedId",
                table: "CustomerTypes",
                column: "UserCreatedId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_dbo_Employees_Order",
                table: "Employees",
                column: "Order")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_RecurringAppointment_Id",
                table: "Employees",
                column: "RecurringAppointment_Id")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_UserCreatedId",
                table: "Employees",
                column: "UserCreatedId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_UserId",
                table: "Employees",
                column: "UserId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "Genders",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_UserCreatedId",
                table: "Genders",
                column: "UserCreatedId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Code",
                table: "Languages",
                column: "Code",
                unique: true)
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "Languages",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_UserCreatedId",
                table: "Languages",
                column: "UserCreatedId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "LegalForms",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_UserCreatedId",
                table: "LegalForms",
                column: "UserCreatedId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "Lines",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_UserCreatedId",
                table: "Lines",
                column: "UserCreatedId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Code",
                table: "PaymentConditions",
                column: "Code",
                unique: true)
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "PaymentConditions",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_UserCreatedId",
                table: "PaymentConditions",
                column: "UserCreatedId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_ProductLineDeliveries_UserCreatedId",
                table: "ProductLineDeliveries",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLineDeliveryRelatedId",
                table: "ProductLineDeliveries",
                column: "ProductLineDeliveryRelatedId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLineId",
                table: "ProductLineDeliveries",
                column: "ProductLineId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPeriodTypeId",
                table: "ProductLineDeliveries",
                column: "SalesPeriodTypeId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "Missing_IXNC_ProductLineDeliveries_Code_E640E",
                table: "ProductLineDeliveries",
                column: "Code")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_BrandId",
                table: "ProductLines",
                column: "BrandId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_GenderId",
                table: "ProductLines",
                column: "GenderId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_ProductLines_AgeCategoryId",
                table: "ProductLines",
                column: "AgeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLines_LineId",
                table: "ProductLines",
                column: "LineId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLines_SegmentTypeId",
                table: "ProductLines",
                column: "SegmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLines_UserCreatedId",
                table: "ProductLines",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospections_ShopId",
                table: "Prospections",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryId",
                table: "Provinces",
                column: "CountryId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_UserCreatedId",
                table: "Provinces",
                column: "UserCreatedId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Code",
                table: "Regions",
                column: "Code",
                unique: true)
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "Regions",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_UserCreatedId",
                table: "Regions",
                column: "UserCreatedId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Code",
                table: "SalesPeriods",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_dbo_SalesPeriods_InflationPercentage",
                table: "SalesPeriods",
                column: "InflationPercentage")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "SalesPeriods",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_SalesPeriods_SalesPeriodTypeId",
                table: "SalesPeriods",
                column: "SalesPeriodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShortCode",
                table: "SalesPeriods",
                column: "ShortCode",
                unique: true)
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_UserCreatedId",
                table: "SalesPeriods",
                column: "UserCreatedId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Code",
                table: "SalesPeriodTypes",
                column: "Code",
                unique: true)
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "SalesPeriodTypes",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_SalesPeriodTypes_UserCreatedId",
                table: "SalesPeriodTypes",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Code",
                table: "SegmentTypes",
                column: "Code",
                unique: true)
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "SegmentTypes",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_UserCreatedId",
                table: "SegmentTypes",
                column: "UserCreatedId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_ShopCommercialLocations_CommercialLocationId",
                table: "ShopCommercialLocations",
                column: "CommercialLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopCommercialLocations_Shop_Id",
                table: "ShopCommercialLocations",
                column: "Shop_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserCreatedId",
                table: "ShopCommercialLocations",
                column: "UserCreatedId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_CompetitorBrandId",
                table: "ShopCompetitorBrands",
                column: "CompetitorBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_Id",
                table: "ShopCompetitorBrands",
                column: "Shop_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserCreatedId",
                table: "ShopCompetitorBrands",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_Id",
                table: "ShopCompetitorProductLines",
                column: "Shop_Id")
                .Annotation("SqlServer:FillFactor", 95);

            migrationBuilder.CreateIndex(
                name: "IX_ShopCompetitorProductLines_ProductLineId",
                table: "ShopCompetitorProductLines",
                column: "ProductLineId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopCompetitorProductLines_UserCreatedId",
                table: "ShopCompetitorProductLines",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_Id",
                table: "ShopContacts",
                column: "Shop_Id")
                .Annotation("SqlServer:FillFactor", 95);

            migrationBuilder.CreateIndex(
                name: "IX_ShopContacts_ContactId",
                table: "ShopContacts",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopContacts_ContactTypeId",
                table: "ShopContacts",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopContacts_UserCreatedId",
                table: "ShopContacts",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_dbo_ShopDeliveries_covering",
                table: "ShopDeliveries",
                columns: new[] { "SalesPeriodId", "ShopId", "ProductLineDeliveryId", "ShopDeliveryStateId", "ShopDeliveryTypeId", "Id" })
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_ProductLineDeliveryId",
                table: "ShopDeliveries",
                column: "ProductLineDeliveryId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_ShopDeliveries_CountryId",
                table: "ShopDeliveries",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopDeliveries_ShopDeliveryOriginId",
                table: "ShopDeliveries",
                column: "ShopDeliveryOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopDeliveries_ShopDeliveryTypeId",
                table: "ShopDeliveries",
                column: "ShopDeliveryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopDeliveries_UserCreatedId",
                table: "ShopDeliveries",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopDeliveryReferenceId",
                table: "ShopDeliveries",
                column: "ShopDeliveryReferenceId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_ShopDeliveryStateId",
                table: "ShopDeliveries",
                column: "ShopDeliveryStateId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_ShowroomId",
                table: "ShopDeliveries",
                column: "ShowroomId")
                .Annotation("SqlServer:FillFactor", 95);

            migrationBuilder.CreateIndex(
                name: "Missing_IXNC_ShopDeliveries_ProductLineDeliveryId_SalesPeriodId_560DE",
                table: "ShopDeliveries",
                columns: new[] { "ProductLineDeliveryId", "SalesPeriodId" })
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "Missing_IXNC_ShopDeliveries_ProductLineDeliveryId_SalesPeriodId_BonusBudget_287F6",
                table: "ShopDeliveries",
                columns: new[] { "ProductLineDeliveryId", "SalesPeriodId", "BonusBudget" })
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "Missing_IXNC_ShopDeliveries_ProductLineDeliveryId_SalesPeriodId_BonusBudget_7A816",
                table: "ShopDeliveries",
                columns: new[] { "ProductLineDeliveryId", "SalesPeriodId", "BonusBudget" })
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "Missing_IXNC_ShopDeliveries_ProductLineDeliveryId_SalesPeriodId_CEFF9",
                table: "ShopDeliveries",
                columns: new[] { "ProductLineDeliveryId", "SalesPeriodId" })
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "Missing_IXNC_ShopDeliveries_ProductLineDeliveryId_SalesPeriodId_D7830",
                table: "ShopDeliveries",
                columns: new[] { "ProductLineDeliveryId", "SalesPeriodId" })
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "Missing_IXNC_ShopDeliveries_ProductLineDeliveryId_SalesPeriodId_DF56C",
                table: "ShopDeliveries",
                columns: new[] { "ProductLineDeliveryId", "SalesPeriodId" })
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "Missing_IXNC_ShopDeliveries_ProductLineDeliveryId_SalesPeriodId_IgnoreBonusBudget_9A6C4",
                table: "ShopDeliveries",
                columns: new[] { "ProductLineDeliveryId", "SalesPeriodId", "IgnoreBonusBudget" })
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "Missing_IXNC_ShopDeliveries_ProductLineDeliveryId_SalesPeriodId_IgnoreBonusBudget_C7B56",
                table: "ShopDeliveries",
                columns: new[] { "ProductLineDeliveryId", "SalesPeriodId", "IgnoreBonusBudget" })
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "Missing_IXNC_ShopDeliveries_ProductLineDeliveryId_SalesPeriodId_IgnoreBonusBudget_ShopDeliveryReferenceId_544C0",
                table: "ShopDeliveries",
                columns: new[] { "ProductLineDeliveryId", "SalesPeriodId", "IgnoreBonusBudget", "ShopDeliveryReferenceId" })
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "Missing_IXNC_ShopDeliveries_ProductLineDeliveryId_SalesPeriodId_ShopDeliveryStateId_DF953",
                table: "ShopDeliveries",
                columns: new[] { "ProductLineDeliveryId", "SalesPeriodId", "ShopDeliveryStateId" })
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "Missing_IXNC_ShopDeliveries_ProductLineDeliveryId_SalesPeriodId_ShopDeliveryStateId_ShopId_CEE40",
                table: "ShopDeliveries",
                columns: new[] { "ProductLineDeliveryId", "SalesPeriodId", "ShopDeliveryStateId", "ShopId" })
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "Missing_IXNC_ShopDeliveries_ProductLineDeliveryId_SalesPeriodId_ShopId_6261E",
                table: "ShopDeliveries",
                columns: new[] { "ProductLineDeliveryId", "SalesPeriodId", "ShopId" })
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "Missing_IXNC_ShopDeliveries_SalesPeriodId_ProductLineDeliveryId_OrderAmount_100F7",
                table: "ShopDeliveries",
                columns: new[] { "SalesPeriodId", "ProductLineDeliveryId", "OrderAmount" })
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "Missing_IXNC_ShopDeliveries_ShopDeliveryReferenceId_ProductLineDeliveryId_SalesPeriodId_4D1F0",
                table: "ShopDeliveries",
                columns: new[] { "ShopDeliveryReferenceId", "ProductLineDeliveryId", "SalesPeriodId" })
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "Missing_IXNC_ShopDeliveries_ShopDeliveryReferenceId_SalesPeriodId_6F78B",
                table: "ShopDeliveries",
                columns: new[] { "ShopDeliveryReferenceId", "SalesPeriodId" })
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "Missing_IXNC_ShopDeliveries_ShopId_306A0",
                table: "ShopDeliveries",
                column: "ShopId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "Missing_IXNC_ShopDeliveries_ShopId_3EB0D",
                table: "ShopDeliveries",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "Missing_IXNC_ShopDeliveries_ShopId_ProductLineDeliveryId_SalesPeriodId_545FA",
                table: "ShopDeliveries",
                columns: new[] { "ShopId", "ProductLineDeliveryId", "SalesPeriodId" })
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "Missing_IXNC_ShopDeliveries_ShopId_ProductLineDeliveryId_SalesPeriodId_7E2A6",
                table: "ShopDeliveries",
                columns: new[] { "ShopId", "ProductLineDeliveryId", "SalesPeriodId" })
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "Missing_IXNC_ShopDeliveries_ShopId_ProductLineDeliveryId_SalesPeriodId_Id_B6A09",
                table: "ShopDeliveries",
                columns: new[] { "ShopId", "ProductLineDeliveryId", "SalesPeriodId", "Id" })
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Code",
                table: "ShopDeliveryOrigins",
                column: "Code",
                unique: true)
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "ShopDeliveryOrigins",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_UserCreatedId",
                table: "ShopDeliveryOrigins",
                column: "UserCreatedId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Code",
                table: "ShopDeliveryStates",
                column: "Code",
                unique: true)
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "ShopDeliveryStates",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_UserCreatedId",
                table: "ShopDeliveryStates",
                column: "UserCreatedId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Code",
                table: "ShopDeliveryTypes",
                column: "Code",
                unique: true)
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "ShopDeliveryTypes",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_UserCreatedId",
                table: "ShopDeliveryTypes",
                column: "UserCreatedId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_GenderId",
                table: "ShopGenders",
                column: "GenderId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Shop_Id",
                table: "ShopGenders",
                column: "Shop_Id")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_UserCreatedId",
                table: "ShopGenders",
                column: "UserCreatedId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_LineId",
                table: "ShopLines",
                column: "LineId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Shop_Id",
                table: "ShopLines",
                column: "Shop_Id")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_UserCreatedId",
                table: "ShopLines",
                column: "UserCreatedId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_ContactId",
                table: "Shops",
                column: "ContactId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Shops_UserCreatedId",
                table: "Shops",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopTypeId",
                table: "Shops",
                column: "ShopTypeId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_SpancoId",
                table: "Shops",
                column: "SpancoId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "ShopTypes",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_UserCreatedId",
                table: "ShopTypes",
                column: "UserCreatedId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "Spancos",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_UserCreatedId",
                table: "Spancos",
                column: "UserCreatedId")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Code",
                table: "VatTypes",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "VatTypes",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL")
                .Annotation("SqlServer:FillFactor", 90);

            migrationBuilder.CreateIndex(
                name: "IX_UserCreatedId",
                table: "VatTypes",
                column: "UserCreatedId")
                .Annotation("SqlServer:FillFactor", 90);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerLegalHistories");

            migrationBuilder.DropTable(
                name: "CustomerShops");

            migrationBuilder.DropTable(
                name: "Prospections");

            migrationBuilder.DropTable(
                name: "ShopCommercialLocations");

            migrationBuilder.DropTable(
                name: "ShopCompetitorBrands");

            migrationBuilder.DropTable(
                name: "ShopCompetitorProductLines");

            migrationBuilder.DropTable(
                name: "ShopContacts");

            migrationBuilder.DropTable(
                name: "ShopDeliveries");

            migrationBuilder.DropTable(
                name: "ShopGenders");

            migrationBuilder.DropTable(
                name: "ShopLines");

            migrationBuilder.DropTable(
                name: "CustomerCodes");

            migrationBuilder.DropTable(
                name: "LegalForms");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "CommercialLocations");

            migrationBuilder.DropTable(
                name: "CompetitorBrands");

            migrationBuilder.DropTable(
                name: "ContactTypes");

            migrationBuilder.DropTable(
                name: "ProductLineDeliveries");

            migrationBuilder.DropTable(
                name: "SalesPeriods");

            migrationBuilder.DropTable(
                name: "ShopDeliveryOrigins");

            migrationBuilder.DropTable(
                name: "ShopDeliveryStates");

            migrationBuilder.DropTable(
                name: "ShopDeliveryTypes");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "BlockedTypes");

            migrationBuilder.DropTable(
                name: "CustomerTypes");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ProductLines");

            migrationBuilder.DropTable(
                name: "SalesPeriodTypes");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "ShopTypes");

            migrationBuilder.DropTable(
                name: "Spancos");

            migrationBuilder.DropTable(
                name: "AgeCategories");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Lines");

            migrationBuilder.DropTable(
                name: "SegmentTypes");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "PaymentConditions");

            migrationBuilder.DropTable(
                name: "VatTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropSequence(
                name: "AccountingSessionNumberSequence");

            migrationBuilder.DropSequence(
                name: "AllocationNumberSequence");

            migrationBuilder.DropSequence(
                name: "B2CLinkedNumberSequence");

            migrationBuilder.DropSequence(
                name: "B2CReturnNumberSequence");

            migrationBuilder.DropSequence(
                name: "B2CUploadNumberSequence");

            migrationBuilder.DropSequence(
                name: "BackOrderNumberSequence");

            migrationBuilder.DropSequence(
                name: "BatchNumberSequence");

            migrationBuilder.DropSequence(
                name: "BleckmannInventoryNumberSequence");

            migrationBuilder.DropSequence(
                name: "BlockedDeliveryNumberSequence");

            migrationBuilder.DropSequence(
                name: "BorrowNumberSequence");

            migrationBuilder.DropSequence(
                name: "brandMIRACLESEanCodeSequence");

            migrationBuilder.DropSequence(
                name: "brandSVNTYEanCodeSequence");

            migrationBuilder.DropSequence(
                name: "brandWildwonEanCodeSequence");

            migrationBuilder.DropSequence(
                name: "BulkConfirmationNumberSequence");

            migrationBuilder.DropSequence(
                name: "BulkDeliveryNumberSequence");

            migrationBuilder.DropSequence(
                name: "BulkOrderNumberSequence");

            migrationBuilder.DropSequence(
                name: "BulkReturnIncomingNumberSequence");

            migrationBuilder.DropSequence(
                name: "BulkReturnPacklistNumberSequence");

            migrationBuilder.DropSequence(
                name: "CanceledNumberSequence");

            migrationBuilder.DropSequence(
                name: "ColorSkuSequence");

            migrationBuilder.DropSequence(
                name: "ConfirmationNumberSequence");

            migrationBuilder.DropSequence(
                name: "ConsignmentNumberSequence");

            migrationBuilder.DropSequence(
                name: "DebitCreditNoteNumberSequence");

            migrationBuilder.DropSequence(
                name: "DebitNoteNumberSequence");

            migrationBuilder.DropSequence(
                name: "DeliveryNoteNumberSequence");

            migrationBuilder.DropSequence(
                name: "DraftNumberSequence");

            migrationBuilder.DropSequence(
                name: "EanCodeSequence");

            migrationBuilder.DropSequence(
                name: "FcStoreConfirmationNumberSequence");

            migrationBuilder.DropSequence(
                name: "FcStoreDeliveryNumberSequence");

            migrationBuilder.DropSequence(
                name: "FcStoreReceptionNumberSequence");

            migrationBuilder.DropSequence(
                name: "IncomingBulkDeliveryNumberSequence");

            migrationBuilder.DropSequence(
                name: "IncomingDeliveryNumberSequence");

            migrationBuilder.DropSequence(
                name: "IncomingOccasionalNumberSequence");

            migrationBuilder.DropSequence(
                name: "IncomingPackingListNumberSequence");

            migrationBuilder.DropSequence(
                name: "InventoryNumberSequence");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201500");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201501");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201502");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201503");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201504");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201505");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201506");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201507");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201508");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201509");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201510");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201511");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201512");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201513");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201514");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201515");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201516");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201517");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201518");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201519");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201520");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201521");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201522");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201523");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201524");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201525");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201526");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201527");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201528");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201529");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201530");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201531");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201532");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201533");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201534");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201535");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201536");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201537");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201538");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201539");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201540");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201541");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201542");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201543");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201544");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201545");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201546");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201547");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201548");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201549");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201550");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201551");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201552");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201553");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201554");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201555");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201556");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201557");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201558");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201559");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201560");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201561");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201562");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201563");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201564");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201565");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201566");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201567");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201568");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201569");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201570");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201571");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201572");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201573");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201574");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201575");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201576");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201577");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201578");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201579");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201580");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201581");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201582");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201583");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201584");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201585");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201586");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201587");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201588");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201589");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201590");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201591");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201592");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201595");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201597");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201599");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201600");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201602");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201605");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201606");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201608");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201609");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201610");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201611");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201614");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201615");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201616");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201617");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201618");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201620");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201622");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201624");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201625");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201627");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201629");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201630");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201632");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201638");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201639");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201640");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201641");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201642");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201645");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201647");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201648");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201650");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201654");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201656");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201659");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201661");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201662");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201664");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201665");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201667");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201668");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201669");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201670");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201672");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201675");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201676");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201679");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201681");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201688");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201692");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201695");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201697");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201700");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201702");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201706");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201710");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201711");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201714");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201720");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201722");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201724");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201727");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201729");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201730");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201734");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201738");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201739");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201740");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201741");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201742");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201745");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201748");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201756");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201759");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201761");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201764");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201765");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201767");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201768");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201770");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201772");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201776");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201779");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201781");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201784");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201788");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201792");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201793");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201795");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201797");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201799");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201800");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2018000");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201802");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201803");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201806");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201809");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201810");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201811");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201814");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201815");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201817");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201820");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201821");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201822");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201823");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201826");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201827");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201829");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201830");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2018300");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2018301");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2018302");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201831");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201835");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201836");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201837");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201838");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201839");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201840");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201842");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201843");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201844");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201845");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2018501");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201852");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201854");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201856");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201859");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201867");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201868");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201871");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201876");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201879");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201881");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201884");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201886");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201888");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201892");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201893");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201897");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201899");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201900");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence201903");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019301");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019302");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019402");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019403");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019405");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019409");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019413");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019414");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019415");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019416");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019419");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019420");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019421");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019422");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019423");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019424");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019425");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019426");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019428");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019429");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019430");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019431");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019433");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019435");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019438");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019439");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019440");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019441");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019443");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019444");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019446");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019454");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019458");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019459");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019467");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019468");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019471");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019476");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019481");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019483");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019484");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019488");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019497");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019499");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019501");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019520");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2019530");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence202000");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence202010");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020301");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020302");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020400");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020402");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020403");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020405");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020409");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020413");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020414");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020415");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020420");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020422");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020425");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020426");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020428");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020429");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020430");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020431");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020433");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020434");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020436");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020439");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020440");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020441");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020443");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020444");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020458");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020471");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020476");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020484");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020488");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020497");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020499");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020501");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020520");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020530");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2020601");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence202100");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence202110");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021301");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021403");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021404");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021408");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021412");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021414");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021415");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021416");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021420");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021425");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021426");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021428");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021429");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021430");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021433");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021434");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021436");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021443");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021444");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021452");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021458");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021462");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021484");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021488");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021497");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021499");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021501");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence202151");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021520");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021530");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021601");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021701");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2021801");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence202200");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022301");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022403");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022404");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022405");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022407");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022408");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022410");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022412");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022413");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022415");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022416");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022419");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022420");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022426");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022429");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022430");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022434");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022443");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022444");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022452");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022458");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022462");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022465");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022475");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022476");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022484");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022488");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022497");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022499");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022501");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022520");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022530");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022601");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022701");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2022801");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence202300");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence202310");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023301");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023403");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023404");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023407");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023408");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023410");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023413");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023415");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023416");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023417");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023420");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023426");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023427");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023429");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023432");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023434");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023441");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023443");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023444");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023458");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023462");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023465");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023475");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023484");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023488");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023499");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023501");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023520");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023530");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023601");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023701");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2023801");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence202400");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024301");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024303");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024307");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024403");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024407");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024408");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024414");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024415");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024416");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024417");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024420");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024426");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024427");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024429");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024432");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024435");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024437");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024441");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024443");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024445");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024458");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024465");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024475");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024484");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024488");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024499");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024501");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024520");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024530");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024601");

            migrationBuilder.DropSequence(
                name: "InvoiceNumberSequence2024801");

            migrationBuilder.DropSequence(
                name: "MancoNumberSequence");

            migrationBuilder.DropSequence(
                name: "MiscInvoiceNumberSequence");

            migrationBuilder.DropSequence(
                name: "MiscProformaNumberSequence");

            migrationBuilder.DropSequence(
                name: "OccasionalStockNumberSequence");

            migrationBuilder.DropSequence(
                name: "OrderAtSupplierNumberSequence");

            migrationBuilder.DropSequence(
                name: "OrderNumberSequence");

            migrationBuilder.DropSequence(
                name: "PackingListNumberSequence");

            migrationBuilder.DropSequence(
                name: "PosCancelledTicketNumberSequence");

            migrationBuilder.DropSequence(
                name: "PosInvoiceNumberSequence2016492");

            migrationBuilder.DropSequence(
                name: "PosInvoiceNumberSequence2017492");

            migrationBuilder.DropSequence(
                name: "PosInvoiceNumberSequence2018492");

            migrationBuilder.DropSequence(
                name: "PosInvoiceNumberSequence2019492");

            migrationBuilder.DropSequence(
                name: "PosInvoiceNumberSequence2020492");

            migrationBuilder.DropSequence(
                name: "PosInvoiceNumberSequence2021492");

            migrationBuilder.DropSequence(
                name: "PosInvoiceNumberSequence2022492");

            migrationBuilder.DropSequence(
                name: "PosInvoiceNumberSequence2023492");

            migrationBuilder.DropSequence(
                name: "PosInvoiceNumberSequence2024492");

            migrationBuilder.DropSequence(
                name: "PosITSRequestIdNumberSequence");

            migrationBuilder.DropSequence(
                name: "PosNumberSequence");

            migrationBuilder.DropSequence(
                name: "PosParkedTicketNumberSequence");

            migrationBuilder.DropSequence(
                name: "PosReceiverNumberSequence");

            migrationBuilder.DropSequence(
                name: "PosSenderNumberSequence");

            migrationBuilder.DropSequence(
                name: "PosTransportNumberSequence");

            migrationBuilder.DropSequence(
                name: "ReorderNumberSequence");

            migrationBuilder.DropSequence(
                name: "ReturnNumberSequence");

            migrationBuilder.DropSequence(
                name: "SampleLoanNumberSequence");

            migrationBuilder.DropSequence(
                name: "SampleSelectionNumberSequence");

            migrationBuilder.DropSequence(
                name: "SampleToFC70NumberSequence");

            migrationBuilder.DropSequence(
                name: "SampleToPressNumberSequence");

            migrationBuilder.DropSequence(
                name: "SampleToReturn");

            migrationBuilder.DropSequence(
                name: "SampleToReturnNumberSequence");

            migrationBuilder.DropSequence(
                name: "ShoppingBasketNumberSequence");

            migrationBuilder.DropSequence(
                name: "StockAdjustmentNumberSequence");

            migrationBuilder.DropSequence(
                name: "StockDeliveryNumberSequence");

            migrationBuilder.DropSequence(
                name: "StockOrderNumberSequence");

            migrationBuilder.DropSequence(
                name: "StockReceiveTransferNumberSequence");

            migrationBuilder.DropSequence(
                name: "StockSendTransferNumberSequence");

            migrationBuilder.DropSequence(
                name: "SvntyWebOrderNumberSequence");

            migrationBuilder.DropSequence(
                name: "SwapBasketNumberSequence");

            migrationBuilder.DropSequence(
                name: "SwapNumberSequence");

            migrationBuilder.DropSequence(
                name: "TheftNumberSequence");

            migrationBuilder.DropSequence(
                name: "UndefinedStockNumberSequence");

            migrationBuilder.DropSequence(
                name: "WebOrderNumberSequence");
        }
    }
}
