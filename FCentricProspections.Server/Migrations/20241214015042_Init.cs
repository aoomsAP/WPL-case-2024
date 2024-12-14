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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Blocked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentStates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentStates_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ean = table.Column<long>(type: "bigint", nullable: true),
                    MinBulkDeliveryPercentage = table.Column<double>(type: "float", nullable: true),
                    DeliveryFeePercentage = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brands_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetitorBrands",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitorBrands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetitorBrands_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactChannelType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValidationRegex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactChannelType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactChannelType_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsLocation = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactTypes_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyId = table.Column<long>(type: "bigint", nullable: false),
                    PaymentConditionId = table.Column<long>(type: "bigint", nullable: false),
                    VatTypeId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RecurringAppointment_Id = table.Column<long>(type: "bigint", nullable: true),
                    Pin = table.Column<int>(type: "int", nullable: false),
                    AgentId = table.Column<long>(type: "bigint", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesPeriods",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransportCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransportCostLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InflationPercentage = table.Column<int>(type: "int", nullable: false),
                    SalesPeriodTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ShowInWebshop = table.Column<bool>(type: "bit", nullable: false),
                    DeliveryBeginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WpsCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WpsYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LendingPeriodEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShopifySales = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesPeriods_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopTypes_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToDoStatus",
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
                    table.PrimaryKey("PK_ToDoStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoStatus_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_ToDoTypes_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductLines",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<long>(type: "bigint", nullable: false),
                    LineId = table.Column<long>(type: "bigint", nullable: false),
                    GenderId = table.Column<long>(type: "bigint", nullable: false),
                    AgeCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    SegmentTypeId = table.Column<long>(type: "bigint", nullable: false),
                    AveragePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RadiusExclusivity = table.Column<int>(type: "int", nullable: false),
                    FashionLevel = table.Column<int>(type: "int", nullable: false),
                    IsCompetitor = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductLines_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductLines_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactChannelDescriptions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactChannelTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactChannelDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactChannelDescriptions_ContactChannelType_ContactChannelTypeId",
                        column: x => x.ContactChannelTypeId,
                        principalTable: "ContactChannelType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactChannelDescriptions_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    ProvinceId = table.Column<long>(type: "bigint", nullable: true),
                    RegionId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    SearchName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cities_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentStateId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsFixedAppointment = table.Column<bool>(type: "bit", nullable: false),
                    RecurringKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_AppointmentStates_AppointmentStateId",
                        column: x => x.AppointmentStateId,
                        principalTable: "AppointmentStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToDoes",
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
                    table.PrimaryKey("PK_ToDoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoes_ToDoStatus_ToDoStatusId",
                        column: x => x.ToDoStatusId,
                        principalTable: "ToDoStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToDoes_ToDoTypes_ToDoTypeId",
                        column: x => x.ToDoTypeId,
                        principalTable: "ToDoTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToDoes_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductLineDeliveries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesPeriodTypeId = table.Column<long>(type: "bigint", nullable: true),
                    SalesTime = table.Column<int>(type: "int", nullable: false),
                    IsInUse = table.Column<bool>(type: "bit", nullable: false),
                    ProductLineId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    SupplierReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductLineDeliveryRelatedId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLineDeliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductLineDeliveries_ProductLineDeliveries_ProductLineDeliveryRelatedId",
                        column: x => x.ProductLineDeliveryRelatedId,
                        principalTable: "ProductLineDeliveries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductLineDeliveries_ProductLines_ProductLineId",
                        column: x => x.ProductLineId,
                        principalTable: "ProductLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductLineDeliveries_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attention = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<long>(type: "bigint", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    BlockedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BlockedReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iban = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankCityId = table.Column<long>(type: "bigint", nullable: true),
                    VatTypeId = table.Column<long>(type: "bigint", nullable: true),
                    KeyAccountManagerId = table.Column<long>(type: "bigint", nullable: true),
                    DeliveryLocationTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsKeyAccount = table.Column<bool>(type: "bit", nullable: false),
                    SearchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    AnniversaryDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AccountingCodeId = table.Column<long>(type: "bigint", nullable: true),
                    IsKeyClient = table.Column<bool>(type: "bit", nullable: false),
                    GenderId = table.Column<long>(type: "bigint", nullable: true),
                    MiscAccountingCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IgnoreInReporting = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Cities_BankCityId",
                        column: x => x.BankCityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customers_Employees_KeyAccountManagerId",
                        column: x => x.KeyAccountManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
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
                        name: "FK_ToDoEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToDoEmployees_ToDoes_ToDoId",
                        column: x => x.ToDoId,
                        principalTable: "ToDoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<long>(type: "bigint", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSupplierContact = table.Column<bool>(type: "bit", nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    WebUserId = table.Column<long>(type: "bigint", nullable: true),
                    SearchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SearchName2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contacts_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactChannels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactChannelDescriptionId = table.Column<long>(type: "bigint", nullable: false),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Contact_Id = table.Column<long>(type: "bigint", nullable: true),
                    UseForAppointmentEmails = table.Column<bool>(type: "bit", nullable: false),
                    ContactId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactChannels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactChannels_ContactChannelDescriptions_ContactChannelDescriptionId",
                        column: x => x.ContactChannelDescriptionId,
                        principalTable: "ContactChannelDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactChannels_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactChannels_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpeningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Area = table.Column<int>(type: "int", nullable: true),
                    SalesPeople = table.Column<int>(type: "int", nullable: true),
                    DisplayWindows = table.Column<int>(type: "int", nullable: true),
                    Floors = table.Column<int>(type: "int", nullable: true),
                    ShopTypeId = table.Column<long>(type: "bigint", nullable: true),
                    SpancoId = table.Column<long>(type: "bigint", nullable: true),
                    ContactId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    SearchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsParallelSales = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shops_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Shops_ShopTypes_ShopTypeId",
                        column: x => x.ShopTypeId,
                        principalTable: "ShopTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Shops_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerShops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerShops_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerShops_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerShops_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FashionDocuments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesPeriodId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerLegalHistoryId = table.Column<long>(type: "bigint", nullable: false),
                    DeliveryAddressId = table.Column<long>(type: "bigint", nullable: false),
                    DeliveryMethodId = table.Column<long>(type: "bigint", nullable: true),
                    PaymentConditionId = table.Column<long>(type: "bigint", nullable: false),
                    AccountingCodeId = table.Column<long>(type: "bigint", nullable: false),
                    FileImportLogId = table.Column<long>(type: "bigint", nullable: true),
                    PosId = table.Column<long>(type: "bigint", nullable: true),
                    PublicationId = table.Column<long>(type: "bigint", nullable: true),
                    LoyaltyVoucherBarcodeId = table.Column<long>(type: "bigint", nullable: true),
                    PosTicketCancellationReasonId = table.Column<long>(type: "bigint", nullable: true),
                    PosTicketCancellationReasonDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailInvoicingTeam = table.Column<bool>(type: "bit", nullable: false),
                    TransferHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceShopId = table.Column<long>(type: "bigint", nullable: true),
                    DestinationShopId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FashionDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FashionDocuments_Contacts_DeliveryAddressId",
                        column: x => x.DeliveryAddressId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FashionDocuments_SalesPeriods_SalesPeriodId",
                        column: x => x.SalesPeriodId,
                        principalTable: "SalesPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FashionDocuments_Shops_DestinationShopId",
                        column: x => x.DestinationShopId,
                        principalTable: "Shops",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FashionDocuments_Shops_SourceShopId",
                        column: x => x.SourceShopId,
                        principalTable: "Shops",
                        principalColumn: "Id");
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
                name: "ShopContacts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactId = table.Column<long>(type: "bigint", nullable: false),
                    ContactTypeId = table.Column<long>(type: "bigint", nullable: false),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Shop_Id = table.Column<long>(type: "bigint", nullable: true),
                    ShopId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopContacts_ContactTypes_ContactTypeId",
                        column: x => x.ContactTypeId,
                        principalTable: "ContactTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopContacts_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopContacts_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
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
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    StockLocationId = table.Column<long>(type: "bigint", nullable: true),
                    BonusBudget = table.Column<int>(type: "int", nullable: true),
                    IgnoreBonusBudget = table.Column<bool>(type: "bit", nullable: false),
                    CanSwap = table.Column<bool>(type: "bit", nullable: false),
                    MarginPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ShowroomId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopDeliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopDeliveries_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShopDeliveries_ProductLineDeliveries_ProductLineDeliveryId",
                        column: x => x.ProductLineDeliveryId,
                        principalTable: "ProductLineDeliveries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopDeliveries_SalesPeriods_SalesPeriodId",
                        column: x => x.SalesPeriodId,
                        principalTable: "SalesPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopDeliveries_ShopDeliveries_ShopDeliveryReferenceId",
                        column: x => x.ShopDeliveryReferenceId,
                        principalTable: "ShopDeliveries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShopDeliveries_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShopDeliveries_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FashionDocumentShops",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopId = table.Column<long>(type: "bigint", nullable: false),
                    UserCreatedId = table.Column<long>(type: "bigint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FashionDocument_Id = table.Column<long>(type: "bigint", nullable: false),
                    FashionDocumentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FashionDocumentShops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FashionDocumentShops_FashionDocuments_FashionDocumentId",
                        column: x => x.FashionDocumentId,
                        principalTable: "FashionDocuments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FashionDocumentShops_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FashionDocumentShops_Users_UserCreatedId",
                        column: x => x.UserCreatedId,
                        principalTable: "Users",
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

            migrationBuilder.InsertData(
                table: "ShopTypes",
                columns: new[] { "Id", "DateCreated", "Name", "UserCreatedId" },
                values: new object[] { 6L, new DateTime(2024, 12, 14, 2, 50, 42, 190, DateTimeKind.Local).AddTicks(292), "Prospection", 103L });

            migrationBuilder.InsertData(
                table: "ToDoStatus",
                columns: new[] { "Id", "DateCreated", "Name", "UserCreatedId" },
                values: new object[] { 1L, new DateTime(2024, 12, 14, 2, 50, 42, 190, DateTimeKind.Local).AddTicks(267), "Ongoing", 103L });

            migrationBuilder.InsertData(
                table: "ToDoTypes",
                columns: new[] { "Id", "AssignEmployeesQuery", "DateCreated", "Name", "UserCreatedId" },
                values: new object[,]
                {
                    { 1L, null, new DateTime(2024, 12, 14, 2, 50, 42, 190, DateTimeKind.Local).AddTicks(168), "New contact info", 103L },
                    { 2L, null, new DateTime(2024, 12, 14, 2, 50, 42, 190, DateTimeKind.Local).AddTicks(237), "New brands", 103L },
                    { 3L, null, new DateTime(2024, 12, 14, 2, 50, 42, 190, DateTimeKind.Local).AddTicks(240), "Brand interests", 103L },
                    { 4L, null, new DateTime(2024, 12, 14, 2, 50, 42, 190, DateTimeKind.Local).AddTicks(242), "Other", 103L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserCreatedId",
                table: "Addresses",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentStateId",
                table: "Appointments",
                column: "AppointmentStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_EmployeeId",
                table: "Appointments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_UserCreatedId",
                table: "Appointments",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentStates_UserCreatedId",
                table: "AppointmentStates",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_UserCreatedId",
                table: "Brands",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_UserCreatedId",
                table: "Cities",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitorBrands_UserCreatedId",
                table: "CompetitorBrands",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactChannelDescriptions_ContactChannelTypeId",
                table: "ContactChannelDescriptions",
                column: "ContactChannelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactChannelDescriptions_UserCreatedId",
                table: "ContactChannelDescriptions",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactChannels_ContactChannelDescriptionId",
                table: "ContactChannels",
                column: "ContactChannelDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactChannels_ContactId",
                table: "ContactChannels",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactChannels_UserCreatedId",
                table: "ContactChannels",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactChannelType_UserCreatedId",
                table: "ContactChannelType",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_AddressId",
                table: "Contacts",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserCreatedId",
                table: "Contacts",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactTypes_UserCreatedId",
                table: "ContactTypes",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_UserCreatedId",
                table: "Countries",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BankCityId",
                table: "Customers",
                column: "BankCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_KeyAccountManagerId",
                table: "Customers",
                column: "KeyAccountManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserCreatedId",
                table: "Customers",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerShops_CustomerId",
                table: "CustomerShops",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerShops_ShopId",
                table: "CustomerShops",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerShops_UserCreatedId",
                table: "CustomerShops",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserCreatedId",
                table: "Employees",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_FashionDocuments_DeliveryAddressId",
                table: "FashionDocuments",
                column: "DeliveryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_FashionDocuments_DestinationShopId",
                table: "FashionDocuments",
                column: "DestinationShopId");

            migrationBuilder.CreateIndex(
                name: "IX_FashionDocuments_SalesPeriodId",
                table: "FashionDocuments",
                column: "SalesPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_FashionDocuments_SourceShopId",
                table: "FashionDocuments",
                column: "SourceShopId");

            migrationBuilder.CreateIndex(
                name: "IX_FashionDocumentShops_FashionDocumentId",
                table: "FashionDocumentShops",
                column: "FashionDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_FashionDocumentShops_ShopId",
                table: "FashionDocumentShops",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_FashionDocumentShops_UserCreatedId",
                table: "FashionDocumentShops",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLineDeliveries_ProductLineDeliveryRelatedId",
                table: "ProductLineDeliveries",
                column: "ProductLineDeliveryRelatedId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLineDeliveries_ProductLineId",
                table: "ProductLineDeliveries",
                column: "ProductLineId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLineDeliveries_UserCreatedId",
                table: "ProductLineDeliveries",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLines_BrandId",
                table: "ProductLines",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLines_UserCreatedId",
                table: "ProductLines",
                column: "UserCreatedId");

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
                name: "IX_ProspectionToDos_ProspectionId",
                table: "ProspectionToDos",
                column: "ProspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProspectionToDos_ToDoId",
                table: "ProspectionToDos",
                column: "ToDoId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPeriods_UserCreatedId",
                table: "SalesPeriods",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopContacts_ContactId",
                table: "ShopContacts",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopContacts_ContactTypeId",
                table: "ShopContacts",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopContacts_ShopId",
                table: "ShopContacts",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopDeliveries_CountryId",
                table: "ShopDeliveries",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopDeliveries_ProductLineDeliveryId",
                table: "ShopDeliveries",
                column: "ProductLineDeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopDeliveries_SalesPeriodId",
                table: "ShopDeliveries",
                column: "SalesPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopDeliveries_ShopDeliveryReferenceId",
                table: "ShopDeliveries",
                column: "ShopDeliveryReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopDeliveries_ShopId",
                table: "ShopDeliveries",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopDeliveries_UserCreatedId",
                table: "ShopDeliveries",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_ContactId",
                table: "Shops",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_ShopTypeId",
                table: "Shops",
                column: "ShopTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_UserCreatedId",
                table: "Shops",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopTypes_UserCreatedId",
                table: "ShopTypes",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoEmployees_EmployeeId",
                table: "ToDoEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoEmployees_ToDoId",
                table: "ToDoEmployees",
                column: "ToDoId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoes_ToDoStatusId",
                table: "ToDoes",
                column: "ToDoStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoes_ToDoTypeId",
                table: "ToDoes",
                column: "ToDoTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoes_UserCreatedId",
                table: "ToDoes",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoStatus_UserCreatedId",
                table: "ToDoStatus",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoTypes_UserCreatedId",
                table: "ToDoTypes",
                column: "UserCreatedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "ContactChannels");

            migrationBuilder.DropTable(
                name: "CustomerShops");

            migrationBuilder.DropTable(
                name: "FashionDocumentShops");

            migrationBuilder.DropTable(
                name: "ProspectionBrandInterests");

            migrationBuilder.DropTable(
                name: "ProspectionBrands");

            migrationBuilder.DropTable(
                name: "ProspectionCompetitorBrands");

            migrationBuilder.DropTable(
                name: "ProspectionToDos");

            migrationBuilder.DropTable(
                name: "ShopContacts");

            migrationBuilder.DropTable(
                name: "ShopDeliveries");

            migrationBuilder.DropTable(
                name: "ToDoEmployees");

            migrationBuilder.DropTable(
                name: "AppointmentStates");

            migrationBuilder.DropTable(
                name: "ContactChannelDescriptions");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "FashionDocuments");

            migrationBuilder.DropTable(
                name: "CompetitorBrands");

            migrationBuilder.DropTable(
                name: "Prospections");

            migrationBuilder.DropTable(
                name: "ContactTypes");

            migrationBuilder.DropTable(
                name: "ProductLineDeliveries");

            migrationBuilder.DropTable(
                name: "ToDoes");

            migrationBuilder.DropTable(
                name: "ContactChannelType");

            migrationBuilder.DropTable(
                name: "SalesPeriods");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ProspectionContactTypes");

            migrationBuilder.DropTable(
                name: "ProspectionVisitTypes");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "ProductLines");

            migrationBuilder.DropTable(
                name: "ToDoStatus");

            migrationBuilder.DropTable(
                name: "ToDoTypes");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "ShopTypes");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
