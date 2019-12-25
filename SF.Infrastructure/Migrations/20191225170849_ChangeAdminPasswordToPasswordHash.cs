using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SF.Infrastructure.Migrations
{
    public partial class ChangeAdminPasswordToPasswordHash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Admins");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Admins",
                maxLength: 512,
                nullable: false,
                defaultValue: new byte[] {  });

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Admins",
                maxLength: 512,
                nullable: false,
                defaultValue: new byte[] {  });

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 245, 118, 89, 111, 219, 76, 234, 229, 151, 177, 131, 188, 169, 101, 58, 158, 8, 4, 215, 11, 224, 167, 3, 2, 160, 202, 135, 125, 37, 212, 140, 41, 236, 32, 34, 68, 1, 51, 55, 243, 27, 100, 146, 224, 151, 67, 32, 110, 151, 97, 84, 18, 80, 9, 55, 250, 17, 45, 100, 134, 198, 0, 229, 55 }, new byte[] { 252, 227, 231, 127, 101, 15, 116, 42, 144, 252, 178, 132, 222, 159, 237, 250, 155, 137, 42, 17, 248, 104, 214, 124, 58, 10, 29, 191, 147, 128, 162, 131, 27, 130, 67, 61, 68, 244, 14, 186, 66, 207, 64, 120, 247, 79, 246, 117, 140, 71, 190, 200, 32, 129, 225, 158, 86, 55, 103, 81, 45, 153, 248, 52, 197, 59, 87, 148, 44, 157, 190, 25, 217, 119, 84, 123, 22, 17, 109, 227, 174, 237, 245, 200, 98, 225, 196, 89, 105, 201, 137, 228, 112, 170, 107, 120, 234, 29, 206, 83, 124, 109, 220, 159, 99, 167, 14, 87, 81, 114, 70, 133, 254, 41, 166, 138, 181, 91, 154, 122, 248, 222, 164, 36, 128, 133, 32, 10 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Admins");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Admins",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "Admin12345");
        }
    }
}
