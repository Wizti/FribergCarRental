using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FribergCarRental.Migrations
{
    /// <inheritdoc />
    public partial class tweakedcustomerrentalandcarmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Rentals");
        }
    }
}
