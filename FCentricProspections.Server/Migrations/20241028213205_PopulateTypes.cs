using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FCentricProspections.Server.Migrations
{
    /// <inheritdoc />
    public partial class PopulateTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProspectionContactTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Owner" },
                    { 2L, "Buyer" },
                    { 3L, "Salesperson" },
                    { 4L, "Other" }
                });

            migrationBuilder.InsertData(
                table: "ProspectionVisitTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Prospection" },
                    { 2L, "Swap" },
                    { 3L, "Key account meeting" },
                    { 4L, "Other" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prospections_ContactPersonTypeId",
                table: "Prospections",
                column: "ContactPersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospections_VisitTypeId",
                table: "Prospections",
                column: "VisitTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prospections_ProspectionContactTypes_ContactPersonTypeId",
                table: "Prospections",
                column: "ContactPersonTypeId",
                principalTable: "ProspectionContactTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prospections_ProspectionVisitTypes_VisitTypeId",
                table: "Prospections",
                column: "VisitTypeId",
                principalTable: "ProspectionVisitTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProspectionContactTypes",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ProspectionContactTypes",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ProspectionContactTypes",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ProspectionContactTypes",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "ProspectionVisitTypes",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ProspectionVisitTypes",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ProspectionVisitTypes",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ProspectionVisitTypes",
                keyColumn: "Id",
                keyValue: 4L);
        }
    }
}
