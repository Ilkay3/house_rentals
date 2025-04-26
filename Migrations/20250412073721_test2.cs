using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace house_rentals.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmenityHouse_amenitie");

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "House_amenitieAmenityId",
                table: "Amenities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "House_amenitieHouseId",
                table: "Amenities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_TenantId",
                table: "Payments",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Amenities_House_amenitieHouseId_House_amenitieAmenityId",
                table: "Amenities",
                columns: new[] { "House_amenitieHouseId", "House_amenitieAmenityId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Amenities_House_Amanities_House_amenitieHouseId_House_amenit~",
                table: "Amenities",
                columns: new[] { "House_amenitieHouseId", "House_amenitieAmenityId" },
                principalTable: "House_Amanities",
                principalColumns: new[] { "HouseId", "AmenityId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Tenants_TenantId",
                table: "Payments",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amenities_House_Amanities_House_amenitieHouseId_House_amenit~",
                table: "Amenities");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Tenants_TenantId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_TenantId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Amenities_House_amenitieHouseId_House_amenitieAmenityId",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "House_amenitieAmenityId",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "House_amenitieHouseId",
                table: "Amenities");

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
        }
    }
}
