using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace house_rentals.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Tenants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_BookingId",
                table: "Tenants",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Bookings_BookingId",
                table: "Tenants",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Bookings_BookingId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_BookingId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Tenants");
        }
    }
}
