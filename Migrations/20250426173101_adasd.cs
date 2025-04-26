using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace house_rentals.Migrations
{
    /// <inheritdoc />
    public partial class adasd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amenities_House_Amanities_House_amenitieHouseId_House_amenit~",
                table: "Amenities");

            migrationBuilder.DropTable(
                name: "House_Amanities");

            migrationBuilder.RenameColumn(
                name: "House_amenitieHouseId",
                table: "Amenities",
                newName: "House_AmenityHouseId");

            migrationBuilder.RenameColumn(
                name: "House_amenitieAmenityId",
                table: "Amenities",
                newName: "House_AmenityAmenityId");

            migrationBuilder.RenameIndex(
                name: "IX_Amenities_House_amenitieHouseId_House_amenitieAmenityId",
                table: "Amenities",
                newName: "IX_Amenities_House_AmenityHouseId_House_AmenityAmenityId");

            migrationBuilder.CreateTable(
                name: "House_Amenities",
                columns: table => new
                {
                    HouseId = table.Column<int>(type: "int", nullable: false),
                    AmenityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House_Amenities", x => new { x.HouseId, x.AmenityId });
                    table.ForeignKey(
                        name: "FK_House_Amenities_Amenities_AmenityId",
                        column: x => x.AmenityId,
                        principalTable: "Amenities",
                        principalColumn: "AmenityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_House_Amenities_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "HouseId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_House_Amenities_AmenityId",
                table: "House_Amenities",
                column: "AmenityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Amenities_House_Amenities_House_AmenityHouseId_House_Amenity~",
                table: "Amenities",
                columns: new[] { "House_AmenityHouseId", "House_AmenityAmenityId" },
                principalTable: "House_Amenities",
                principalColumns: new[] { "HouseId", "AmenityId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amenities_House_Amenities_House_AmenityHouseId_House_Amenity~",
                table: "Amenities");

            migrationBuilder.DropTable(
                name: "House_Amenities");

            migrationBuilder.RenameColumn(
                name: "House_AmenityHouseId",
                table: "Amenities",
                newName: "House_amenitieHouseId");

            migrationBuilder.RenameColumn(
                name: "House_AmenityAmenityId",
                table: "Amenities",
                newName: "House_amenitieAmenityId");

            migrationBuilder.RenameIndex(
                name: "IX_Amenities_House_AmenityHouseId_House_AmenityAmenityId",
                table: "Amenities",
                newName: "IX_Amenities_House_amenitieHouseId_House_amenitieAmenityId");

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

            migrationBuilder.CreateIndex(
                name: "IX_House_Amanities_AmenityId",
                table: "House_Amanities",
                column: "AmenityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Amenities_House_Amanities_House_amenitieHouseId_House_amenit~",
                table: "Amenities",
                columns: new[] { "House_amenitieHouseId", "House_amenitieAmenityId" },
                principalTable: "House_Amanities",
                principalColumns: new[] { "HouseId", "AmenityId" });
        }
    }
}
