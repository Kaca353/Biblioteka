using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotekaMVC.Migrations
{
    /// <inheritdoc />
    public partial class VracenoField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Vraceno",
                table: "Zaduzenja",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vraceno",
                table: "Zaduzenja");
        }
    }
}
