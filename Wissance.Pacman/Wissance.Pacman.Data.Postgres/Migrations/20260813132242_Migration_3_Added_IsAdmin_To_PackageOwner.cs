using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wissance.Pacman.Data.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class Migration_3_Added_IsAdmin_To_PackageOwner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "package_owners",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "package_owners");
        }
    }
}
