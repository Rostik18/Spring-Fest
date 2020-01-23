using Microsoft.EntityFrameworkCore.Migrations;

namespace SF.Infrastructure.Migrations
{
    public partial class RemoveFestivalIdColumnFromPartnerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FestivalId",
                table: "Partners");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FestivalId",
                table: "Partners",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
