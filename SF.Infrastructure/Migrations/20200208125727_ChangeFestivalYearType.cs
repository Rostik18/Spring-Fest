using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SF.Infrastructure.Migrations
{
    public partial class ChangeFestivalYearType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Festivals",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.UpdateData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: 1,
                column: "Year",
                value: 2020);

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BarCode", "IsAvailable" },
                values: new object[] { new Guid("073cf1ab-cead-43c0-9444-08431ff51c08"), true });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BarCode", "IsAvailable" },
                values: new object[] { new Guid("9f2b11f1-68c9-4835-a9a7-70a9add909b1"), true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Year",
                table: "Festivals",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: 1,
                column: "Year",
                value: "2020");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BarCode", "IsAvailable" },
                values: new object[] { new Guid("67be354d-5d93-41f9-859a-1f8106670bb6"), true });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BarCode", "IsAvailable" },
                values: new object[] { new Guid("ed7be15e-cfce-4bbd-afd9-228caced78a7"), true });
        }
    }
}
