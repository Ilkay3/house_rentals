using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace house_rentals.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    AmenityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VarChar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.AmenityId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VarChar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    First_Name = table.Column<string>(type: "VarChar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Last_Name = table.Column<string>(type: "VarChar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "VarChar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "VarChar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EGN = table.Column<string>(type: "VarChar(10)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.OwnerId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    TenantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    First_Name = table.Column<string>(type: "VarChar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Last_Name = table.Column<string>(type: "VarChar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EGN = table.Column<string>(type: "VarChar(10)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "VarChar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "VarChar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.TenantId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    HouseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(type: "VarChar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "VarChar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<double>(type: "DOUBLE", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.HouseId);
                    table.ForeignKey(
                        name: "FK_Houses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Houses_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HouseId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "HouseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "TenantId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "House_Amanities",
                columns: table => new
                {
                    HouseId = table.Column<int>(type: "int", nullable: false),
                    AmenityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House_Amanities", x => new { x.HouseId, x.AmenityId });
                    table.ForeignKey(
                        name: "FK_House_Amanities_Amenities_AmenityId",
                        column: x => x.AmenityId,
                        principalTable: "Amenities",
                        principalColumn: "AmenityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_House_Amanities_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "HouseId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Payment_method = table.Column<string>(type: "VarChar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AmenityHouse_amenitie",
                columns: table => new
                {
                    AmenitiesAmenityId = table.Column<int>(type: "int", nullable: false),
                    HouseAmenitiesHouseId = table.Column<int>(type: "int", nullable: false),
                    HouseAmenitiesAmenityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmenityHouse_amenitie", x => new { x.AmenitiesAmenityId, x.HouseAmenitiesHouseId, x.HouseAmenitiesAmenityId });
                    table.ForeignKey(
                        name: "FK_AmenityHouse_amenitie_Amenities_AmenitiesAmenityId",
                        column: x => x.AmenitiesAmenityId,
                        principalTable: "Amenities",
                        principalColumn: "AmenityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AmenityHouse_amenitie_House_Amanities_HouseAmenitiesHouseId_~",
                        columns: x => new { x.HouseAmenitiesHouseId, x.HouseAmenitiesAmenityId },
                        principalTable: "House_Amanities",
                        principalColumns: new[] { "HouseId", "AmenityId" },
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AmenityHouse_amenitie_HouseAmenitiesHouseId_HouseAmenitiesAm~",
                table: "AmenityHouse_amenitie",
                columns: new[] { "HouseAmenitiesHouseId", "HouseAmenitiesAmenityId" });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_HouseId",
                table: "Bookings",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TenantId",
                table: "Bookings",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_House_Amanities_AmenityId",
                table: "House_Amanities",
                column: "AmenityId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_CityId",
                table: "Houses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_OwnerId",
                table: "Houses",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BookingId",
                table: "Payments",
                column: "BookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmenityHouse_amenitie");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "House_Amanities");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
