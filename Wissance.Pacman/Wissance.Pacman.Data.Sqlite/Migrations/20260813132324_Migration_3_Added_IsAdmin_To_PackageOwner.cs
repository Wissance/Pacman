using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wissance.Pacman.Data.Sqlite.Migrations
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
                type: "INTEGER",
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
