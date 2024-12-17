using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FCentricProspections.Server.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
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
                name: "ToDoStatuses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToDoTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignEmployeesQuery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prospections",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopId = table.Column<long>(type: "bigint", nullable: false),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "ToDos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToDoTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ToDoStatusId = table.Column<long>(type: "bigint", nullable: false),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDos_ToDoStatuses_ToDoStatusId",
                        column: x => x.ToDoStatusId,
                        principalTable: "ToDoStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToDos_ToDoTypes_ToDoTypeId",
                        column: x => x.ToDoTypeId,
                        principalTable: "ToDoTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProspectionId = table.Column<long>(type: "bigint", nullable: false),
                    ToDoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProspectionToDos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProspectionToDos_Prospections_ProspectionId",
                        column: x => x.ProspectionId,
                        principalTable: "Prospections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProspectionToDos_ToDos_ToDoId",
                        column: x => x.ToDoId,
                        principalTable: "ToDos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToDoEmployees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToDoId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoEmployees_ToDos_ToDoId",
                        column: x => x.ToDoId,
                        principalTable: "ToDos",
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

            migrationBuilder.InsertData(
                table: "ShopTypes",
                columns: new[] { "Id", "DateCreated", "Name", "UserCreatedId" },
                values: new object[] { 6L, new DateTime(2024, 12, 18, 3, 34, 19, 486, DateTimeKind.Local).AddTicks(2508), "Prospection", 103L });

            migrationBuilder.InsertData(
                table: "ToDoStatuses",
                columns: new[] { "Id", "DateCreated", "Name", "UserCreatedId" },
                values: new object[] { 1L, new DateTime(2024, 12, 18, 3, 34, 19, 485, DateTimeKind.Local).AddTicks(2825), "Ongoing", 103L });

            migrationBuilder.InsertData(
                table: "ToDoTypes",
                columns: new[] { "Id", "AssignEmployeesQuery", "DateCreated", "Name", "UserCreatedId" },
                values: new object[,]
                {
                    { 1L, null, new DateTime(2024, 12, 18, 3, 34, 19, 485, DateTimeKind.Local).AddTicks(2661), "New contact info", 103L },
                    { 2L, null, new DateTime(2024, 12, 18, 3, 34, 19, 485, DateTimeKind.Local).AddTicks(2772), "New brands", 103L },
                    { 3L, null, new DateTime(2024, 12, 18, 3, 34, 19, 485, DateTimeKind.Local).AddTicks(2777), "Brand interests", 103L },
                    { 4L, null, new DateTime(2024, 12, 18, 3, 34, 19, 485, DateTimeKind.Local).AddTicks(2782), "Other", 103L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProspectionBrandInterests_ProspectionId",
                table: "ProspectionBrandInterests",
                column: "ProspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProspectionBrands_ProspectionId",
                table: "ProspectionBrands",
                column: "ProspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProspectionCompetitorBrands_ProspectionId",
                table: "ProspectionCompetitorBrands",
                column: "ProspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospections_ContactTypeId",
                table: "Prospections",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Prospections_VisitTypeId",
                table: "Prospections",
                column: "VisitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProspectionToDos_ProspectionId",
                table: "ProspectionToDos",
                column: "ProspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProspectionToDos_ToDoId",
                table: "ProspectionToDos",
                column: "ToDoId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoEmployees_ToDoId",
                table: "ToDoEmployees",
                column: "ToDoId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_ToDoStatusId",
                table: "ToDos",
                column: "ToDoStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_ToDoTypeId",
                table: "ToDos",
                column: "ToDoTypeId");
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
                name: "ShopTypes");

            migrationBuilder.DropTable(
                name: "ToDoEmployees");

            migrationBuilder.DropTable(
                name: "Prospections");

            migrationBuilder.DropTable(
                name: "ToDos");

            migrationBuilder.DropTable(
                name: "ProspectionContactTypes");

            migrationBuilder.DropTable(
                name: "ProspectionVisitTypes");

            migrationBuilder.DropTable(
                name: "ToDoStatuses");

            migrationBuilder.DropTable(
                name: "ToDoTypes");
        }
    }
}
