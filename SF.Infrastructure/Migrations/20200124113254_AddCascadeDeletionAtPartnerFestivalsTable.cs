using Microsoft.EntityFrameworkCore.Migrations;

namespace SF.Infrastructure.Migrations
{
    public partial class AddCascadeDeletionAtPartnerFestivalsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartnerFestivals_Festivals_FestivalId",
                table: "PartnerFestivals");

            migrationBuilder.DropForeignKey(
                name: "FK_PartnerFestivals_Partners_PartnerId",
                table: "PartnerFestivals");

            migrationBuilder.AddForeignKey(
                name: "FK_PartnerFestivals_Festivals_FestivalId",
                table: "PartnerFestivals",
                column: "FestivalId",
                principalTable: "Festivals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartnerFestivals_Partners_PartnerId",
                table: "PartnerFestivals",
                column: "PartnerId",
                principalTable: "Partners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartnerFestivals_Festivals_FestivalId",
                table: "PartnerFestivals");

            migrationBuilder.DropForeignKey(
                name: "FK_PartnerFestivals_Partners_PartnerId",
                table: "PartnerFestivals");

            migrationBuilder.AddForeignKey(
                name: "FK_PartnerFestivals_Festivals_FestivalId",
                table: "PartnerFestivals",
                column: "FestivalId",
                principalTable: "Festivals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PartnerFestivals_Partners_PartnerId",
                table: "PartnerFestivals",
                column: "PartnerId",
                principalTable: "Partners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
