using Microsoft.EntityFrameworkCore.Migrations;

namespace SF.Infrastructure.Migrations
{
    public partial class OnDeleteBandOrGenreCascadeBandGenreNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BandGenres_Bands_BandId",
                table: "BandGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_BandGenres_Genres_GenreId",
                table: "BandGenres");

            migrationBuilder.AddForeignKey(
                name: "FK_BandGenres_Bands_BandId",
                table: "BandGenres",
                column: "BandId",
                principalTable: "Bands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BandGenres_Genres_GenreId",
                table: "BandGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BandGenres_Bands_BandId",
                table: "BandGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_BandGenres_Genres_GenreId",
                table: "BandGenres");

            migrationBuilder.AddForeignKey(
                name: "FK_BandGenres_Bands_BandId",
                table: "BandGenres",
                column: "BandId",
                principalTable: "Bands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BandGenres_Genres_GenreId",
                table: "BandGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
