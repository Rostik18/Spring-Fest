using Microsoft.EntityFrameworkCore.Migrations;

namespace SF.Infrastructure.Migrations
{
    public partial class AddPhotoURLColumnToBandTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoURL",
                table: "Bands",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoURL",
                table: "Bands");
        }
    }
}
