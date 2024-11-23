using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FCentricProspections.Server.Migrations
{
    /// <inheritdoc />
    public partial class ProspectionsInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProspectionContactTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProspectionContactTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProspectionVisitTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProspectionVisitTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prospections",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContactTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitTypeId = table.Column<long>(type: "bigint", nullable: false),
                    VisitContext = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewBrands = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BestBrands = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorstBrands = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TerminatedBrands = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trends = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extra = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prospections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prospections_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prospections_ProspectionContactTypes_ContactTypeId",
                        column: x => x.ContactTypeId,
                        principalTable: "ProspectionContactTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prospections_ProspectionVisitTypes_VisitTypeId",
                        column: x => x.VisitTypeId,
                        principalTable: "ProspectionVisitTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prospections_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.Prospections_dbo.Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProspectionBrandInterests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProspectionId = table.Column<long>(type: "bigint", nullable: false),
                    BrandId = table.Column<long>(type: "bigint", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProspectionBrandInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProspectionBrandInterests_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProspectionBrandInterests_Prospections_ProspectionId",
                        column: x => x.ProspectionId,
                        principalTable: "Prospections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProspectionBrands",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProspectionId = table.Column<long>(type: "bigint", nullable: false),
                    BrandId = table.Column<long>(type: "bigint", nullable: false),
                    Sellout = table.Column<int>(type: "int", nullable: true),
                    SelloutRemark = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProspectionBrands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProspectionBrands_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProspectionBrands_Prospections_ProspectionId",
                        column: x => x.ProspectionId,
                        principalTable: "Prospections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProspectionCompetitorBrands",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProspectionId = table.Column<long>(type: "bigint", nullable: false),
                    CompetitorBrandId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProspectionCompetitorBrands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProspectionCompetitorBrands_CompetitorBrands_CompetitorBrandId",
                        column: x => x.CompetitorBrandId,
                        principalTable: "CompetitorBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProspectionCompetitorBrands_Prospections_ProspectionId",
                        column: x => x.ProspectionId,
                        principalTable: "Prospections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProspectionToDos",
                columns: table => new
                {
                    ProspectionId = table.Column<long>(type: "bigint", nullable: false),
                    ToDoId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProspectionToDos", x => new { x.ProspectionId, x.ToDoId });
                    table.ForeignKey(
                        name: "FK_ProspectionToDos_Prospections_ProspectionId",
                        column: x => x.ProspectionId,
                        principalTable: "Prospections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProspectionToDos_ToDoes_ToDoId",
                        column: x => x.ToDoId,
                        principalTable: "ToDoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_ProspectionBrandInterests_BrandId",
                table: "ProspectionBrandInterests",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ProspectionBrandInterests_ProspectionId",
                table: "ProspectionBrandInterests",
                column: "ProspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProspectionBrands_BrandId",
                table: "ProspectionBrands",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ProspectionBrands_ProspectionId",
                table: "ProspectionBrands",
                column: "ProspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProspectionCompetitorBrands_CompetitorBrandId",
                table: "ProspectionCompetitorBrands",
                column: "CompetitorBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ProspectionCompetitorBrands_ProspectionId",
                table: "ProspectionCompetitorBrands",
                column: "ProspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospections_ContactTypeId",
                table: "Prospections",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospections_EmployeeId",
                table: "Prospections",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospections_ShopId",
                table: "Prospections",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospections_UserId",
                table: "Prospections",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospections_VisitTypeId",
                table: "Prospections",
                column: "VisitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProspectionToDos_ToDoId",
                table: "ProspectionToDos",
                column: "ToDoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "ProspectionBrandInterests");

            migrationBuilder.DropTable(
                name: "ProspectionBrands");

            migrationBuilder.DropTable(
                name: "ProspectionCompetitorBrands");

            migrationBuilder.DropTable(
                name: "ProspectionToDos");

            migrationBuilder.DropTable(
                name: "Prospections");

            migrationBuilder.DropTable(
                name: "ProspectionContactTypes");

            migrationBuilder.DropTable(
                name: "ProspectionVisitTypes");
        }
    }
}
