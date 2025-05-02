using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace house_rentals.Migrations
{
    /// <inheritdoc />
    public partial class test8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Amenities_House_Amenities_House_AmenityHouseId_House_Amenity~",
            //    table: "Amenities");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Payments_Tenants_TenantId",
            //    table: "Payments");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Tenants_Bookings_BookingId",
            //    table: "Tenants");

            //migrationBuilder.DropIndex(
            //    name: "IX_Tenants_BookingId",
            //    table: "Tenants");

            //migrationBuilder.DropIndex(
            //    name: "IX_Payments_TenantId",
            //    table: "Payments");

            //migrationBuilder.DropIndex(
            //    name: "IX_Amenities_House_AmenityHouseId_House_AmenityAmenityId",
            //    table: "Amenities");

            //migrationBuilder.DropColumn(
            //    name: "BookingId",
            //    table: "Tenants");

            //migrationBuilder.DropColumn(
            //    name: "TenantId",
            //    table: "Payments");

            //migrationBuilder.DropColumn(
            //    name: "House_AmenityAmenityId",
            //    table: "Amenities");

            //migrationBuilder.DropColumn(
            //    name: "House_AmenityHouseId",
            //    table: "Amenities");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Tenants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "House_AmenityAmenityId",
                table: "Amenities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "House_AmenityHouseId",
                table: "Amenities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_BookingId",
                table: "Tenants",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_TenantId",
                table: "Payments",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Amenities_House_AmenityHouseId_House_AmenityAmenityId",
                table: "Amenities",
                columns: new[] { "House_AmenityHouseId", "House_AmenityAmenityId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Amenities_House_Amenities_House_AmenityHouseId_House_Amenity~",
                table: "Amenities",
                columns: new[] { "House_AmenityHouseId", "House_AmenityAmenityId" },
                principalTable: "House_Amenities",
                principalColumns: new[] { "HouseId", "AmenityId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Tenants_TenantId",
                table: "Payments",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Bookings_BookingId",
                table: "Tenants",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId");
        }
    }
}
