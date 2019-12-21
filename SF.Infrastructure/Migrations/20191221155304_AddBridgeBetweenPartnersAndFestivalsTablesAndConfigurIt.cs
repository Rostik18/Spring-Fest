using Microsoft.EntityFrameworkCore.Migrations;

namespace SF.Infrastructure.Migrations
{
    public partial class AddBridgeBetweenPartnersAndFestivalsTablesAndConfigurIt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partners_Festivals_FestivalId",
                table: "Partners");

            migrationBuilder.DropIndex(
                name: "IX_Partners_FestivalId",
                table: "Partners");

            migrationBuilder.CreateTable(
                name: "PartnerFestivals",
                columns: table => new
                {
                    PartnerId = table.Column<int>(nullable: false),
                    FestivalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerFestivals", x => new { x.PartnerId, x.FestivalId });
                    table.ForeignKey(
                        name: "FK_PartnerFestivals_Festivals_FestivalId",
                        column: x => x.FestivalId,
                        principalTable: "Festivals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PartnerFestivals_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartnerFestivals_FestivalId",
                table: "PartnerFestivals",
                column: "FestivalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartnerFestivals");

            migrationBuilder.CreateIndex(
                name: "IX_Partners_FestivalId",
                table: "Partners",
                column: "FestivalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partners_Festivals_FestivalId",
                table: "Partners",
                column: "FestivalId",
                principalTable: "Festivals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
