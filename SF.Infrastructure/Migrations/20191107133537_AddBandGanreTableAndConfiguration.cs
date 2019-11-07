using Microsoft.EntityFrameworkCore.Migrations;

namespace SF.Infrastructure.Migrations
{
    public partial class AddBandGanreTableAndConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BandGenres",
                columns: table => new
                {
                    BandId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BandGenres", x => new { x.BandId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_BandGenres_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BandGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FestivalId",
                table: "Tickets",
                column: "FestivalId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_CustomerId",
                table: "Purchases",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_TicketId",
                table: "Purchases",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Performances_BandId",
                table: "Performances",
                column: "BandId");

            migrationBuilder.CreateIndex(
                name: "IX_Performances_FestivalId",
                table: "Performances",
                column: "FestivalId");

            migrationBuilder.CreateIndex(
                name: "IX_Performances_StageId",
                table: "Performances",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_Partners_FestivalId",
                table: "Partners",
                column: "FestivalId");

            migrationBuilder.CreateIndex(
                name: "IX_BandGenres_GenreId",
                table: "BandGenres",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partners_Festivals_FestivalId",
                table: "Partners",
                column: "FestivalId",
                principalTable: "Festivals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Performances_Bands_BandId",
                table: "Performances",
                column: "BandId",
                principalTable: "Bands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Performances_Festivals_FestivalId",
                table: "Performances",
                column: "FestivalId",
                principalTable: "Festivals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Performances_Stages_StageId",
                table: "Performances",
                column: "StageId",
                principalTable: "Stages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Customers_CustomerId",
                table: "Purchases",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Tickets_TicketId",
                table: "Purchases",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Festivals_FestivalId",
                table: "Tickets",
                column: "FestivalId",
                principalTable: "Festivals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partners_Festivals_FestivalId",
                table: "Partners");

            migrationBuilder.DropForeignKey(
                name: "FK_Performances_Bands_BandId",
                table: "Performances");

            migrationBuilder.DropForeignKey(
                name: "FK_Performances_Festivals_FestivalId",
                table: "Performances");

            migrationBuilder.DropForeignKey(
                name: "FK_Performances_Stages_StageId",
                table: "Performances");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Customers_CustomerId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Tickets_TicketId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Festivals_FestivalId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "BandGenres");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_FestivalId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_CustomerId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_TicketId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Performances_BandId",
                table: "Performances");

            migrationBuilder.DropIndex(
                name: "IX_Performances_FestivalId",
                table: "Performances");

            migrationBuilder.DropIndex(
                name: "IX_Performances_StageId",
                table: "Performances");

            migrationBuilder.DropIndex(
                name: "IX_Partners_FestivalId",
                table: "Partners");
        }
    }
}
