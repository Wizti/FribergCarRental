using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FribergCarRental.Migrations
{
    /// <inheritdoc />
    public partial class addedbuilder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "Users",
                newName: "UserType");

            migrationBuilder.AddColumn<string>(
                name: "Admin_FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Admin_LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Admin_FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Admin_LastName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserType",
                table: "Users",
                newName: "Discriminator");
        }
    }
}
