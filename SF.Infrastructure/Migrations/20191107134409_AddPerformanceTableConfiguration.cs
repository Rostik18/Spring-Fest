using Microsoft.EntityFrameworkCore.Migrations;

namespace SF.Infrastructure.Migrations
{
    public partial class AddPerformanceTableConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Performances_Bands_BandId",
                table: "Performances");

            migrationBuilder.DropForeignKey(
                name: "FK_Performances_Festivals_FestivalId",
                table: "Performances");

            migrationBuilder.DropForeignKey(
                name: "FK_Performances_Stages_StageId",
                table: "Performances");

            migrationBuilder.AddForeignKey(
                name: "FK_Performances_Bands_BandId",
                table: "Performances",
                column: "BandId",
                principalTable: "Bands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Performances_Festivals_FestivalId",
                table: "Performances",
                column: "FestivalId",
                principalTable: "Festivals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Performances_Stages_StageId",
                table: "Performances",
                column: "StageId",
                principalTable: "Stages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Performances_Bands_BandId",
                table: "Performances");

            migrationBuilder.DropForeignKey(
                name: "FK_Performances_Festivals_FestivalId",
                table: "Performances");

            migrationBuilder.DropForeignKey(
                name: "FK_Performances_Stages_StageId",
                table: "Performances");

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
        }
    }
}
