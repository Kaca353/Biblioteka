using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotekaMVC.Migrations
{
    /// <inheritdoc />
    public partial class Zaduzenje : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Zaduzenja_ClanId",
                table: "Zaduzenja",
                column: "ClanId");

            migrationBuilder.CreateIndex(
                name: "IX_Zaduzenja_KnjigaId",
                table: "Zaduzenja",
                column: "KnjigaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zaduzenja_Clanovi_ClanId",
                table: "Zaduzenja",
                column: "ClanId",
                principalTable: "Clanovi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zaduzenja_Knjige_KnjigaId",
                table: "Zaduzenja",
                column: "KnjigaId",
                principalTable: "Knjige",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zaduzenja_Clanovi_ClanId",
                table: "Zaduzenja");

            migrationBuilder.DropForeignKey(
                name: "FK_Zaduzenja_Knjige_KnjigaId",
                table: "Zaduzenja");

            migrationBuilder.DropIndex(
                name: "IX_Zaduzenja_ClanId",
                table: "Zaduzenja");

            migrationBuilder.DropIndex(
                name: "IX_Zaduzenja_KnjigaId",
                table: "Zaduzenja");
        }
    }
}
