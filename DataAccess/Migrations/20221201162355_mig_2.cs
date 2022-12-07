using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAM.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Star",
                table: "Books");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "Star",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
