using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SF.Infrastructure.Migrations
{
    public partial class AddDBSeedForFestival2020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bands",
                columns: new[] { "Id", "Description", "Name", "PhotoURL" },
                values: new object[,]
                {
                    { 1, "Metallica — американський метал-гурт з Лос-Анджелеса, Каліфорнія, яка грає в жанрі треш-метал та хеві-метал. Разом з Slayer, Megadeth та Anthrax входять до «великої четвірки треш-металу». Заснований в 1981 році, коли Джеймс Гетфілд відгукнувся на оголошення барабанщика Ларса Ульріха, розміщене у місцевій газеті.", "Metallica", "https://pimg.mycdn.me/getImage?disableStub=true&type=VIDEO_S_720&skipBlack=true&url=http%3A%2F%2Fi.mycdn.me%2Fimage%3Fid%3D880168864240%26t%3D50%26plc%3DWEB%26tkn%3D*YEVP-NmKvHWbv6RBRnyQxd8Vizs&signatureToken=hb9KMZKxbZF4GYN-Vq8Tuw" },
                    { 2, "Bring Me The Horizon — англійський металкор гурт з міста Шеффілда, заснований в 2004 році. В цей час група складається з вокаліста Олівера Сайкса, гітариста Лі Малії, басиста Метта Кіна, барабанщика Метта Ніколлса і клавішника Джордана Фіша. На сьогодні гурт співпрацює з лейблами RCA Records та Epitaph Records.", "Bring Me the Horizon", "https://i2.wp.com/sova.ponominalu.ru/wp-content/uploads/2019/10/Bring-Me-The-Horizon.jpg?fit=1548%2C1024&ssl=1" },
                    { 3, "Lord of the Lost - німецький готичний металевий гурт з Гамбурга. Гурт створив співак і фронтмен Кріс Хармс.", "Lord of the Lost", "https://fainemisto.com.ua/wp-content/uploads/2019/07/1530649229.jpg" },
                    { 4, "Led Zeppelin - британський рок-гурт, що вважається одним із засновників хард-року та хеві-металу. Led Zeppelin досі високо шанується за музичні досягнення, нестандартність, комерційний успіх і широкий вплив.", "Led Zeppelin", "https://kanal5.com.mk/uploads/10-5526-.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[] { 1, "rostik1804@gmail.com", "Ростислав", "Байцар" });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "Location", "Year" },
                values: new object[] { 1, "https://www.google.com.ua/maps/place/%D0%90%D0%B5%D1%80%D0%BE%D0%B4%D1%80%D0%BE%D0%BC+%C2%AB%D0%A6%D1%83%D0%BD%D1%96%D0%B2%C2%BB+-+%D1%81%D1%82%D1%80%D0%B8%D0%B1%D0%BA%D0%B8+%D0%B7+%D0%BF%D0%B0%D1%80%D0%B0%D1%88%D1%83%D1%82%D0%BE%D0%BC/@49.8211939,23.6848984,16.48z/data=!4m5!3m4!1s0x473b1e99ccdc9dd9:0xb5a7d47bdfe021fc!8m2!3d49.8215501!4d23.6873576?hl=uk", "2020" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 13, "Jazz" },
                    { 12, "R & В" },
                    { 11, "Rep" },
                    { 10, "Hip Hop" },
                    { 9, "Pop" },
                    { 8, "Thrash" },
                    { 6, "Psychedelic Rock" },
                    { 5, "Punk Rock" },
                    { 4, "Folk Rock" },
                    { 3, "Pop Rock" },
                    { 2, "Hard Rock" },
                    { 1, "Rock" },
                    { 7, "Heavy Metal" }
                });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Samsung — південнокорейська транснаціональна компанія-конгломерат, головний офіс якої розташований у Сеулі, Південна Корея. Компанія є найбільшим південнокорейським чеболем.", "Samsung" });

            migrationBuilder.InsertData(
                table: "Stages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "White Stage" },
                    { 1, "Main Stage" },
                    { 3, "Black Stage" }
                });

            migrationBuilder.InsertData(
                table: "BandGenres",
                columns: new[] { "BandId", "GenreId" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 2, 9 },
                    { 1, 8 },
                    { 4, 7 },
                    { 3, 7 },
                    { 3, 1 },
                    { 4, 1 },
                    { 1, 7 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "PartnerFestivals",
                columns: new[] { "PartnerId", "FestivalId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Performances",
                columns: new[] { "Id", "BandId", "BeginingTime", "Duration", "FestivalId", "StageId" },
                values: new object[,]
                {
                    { 2, 2, new DateTimeOffset(new DateTime(2020, 8, 29, 22, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new TimeSpan(0, 1, 10, 0, 0), 1, 1 },
                    { 1, 1, new DateTimeOffset(new DateTime(2020, 8, 30, 22, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new TimeSpan(0, 1, 20, 0, 0), 1, 1 },
                    { 4, 4, new DateTimeOffset(new DateTime(2020, 8, 30, 20, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new TimeSpan(0, 1, 10, 0, 0), 1, 2 },
                    { 3, 1, new DateTimeOffset(new DateTime(2020, 8, 30, 22, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new TimeSpan(0, 1, 20, 0, 0), 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "BeginingTime", "Duration", "FestivalId", "Price", "Type" },
                values: new object[,]
                {
                    { 8, new DateTimeOffset(new DateTime(2020, 8, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 3, 1, 300, 2 },
                    { 7, new DateTimeOffset(new DateTime(2020, 8, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 3, 1, 200, 3 },
                    { 6, new DateTimeOffset(new DateTime(2020, 8, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 1, 500, 1 },
                    { 5, new DateTimeOffset(new DateTime(2020, 8, 29, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 1, 500, 1 },
                    { 4, new DateTimeOffset(new DateTime(2020, 8, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 1, 1, 500, 1 },
                    { 3, new DateTimeOffset(new DateTime(2020, 8, 29, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 1, 700, 1 },
                    { 2, new DateTimeOffset(new DateTime(2020, 8, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 2, 1, 700, 1 },
                    { 1, new DateTimeOffset(new DateTime(2020, 8, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 3, 1, 1000, 1 }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "BarCode", "CustomerId", "IsAvailable", "TicketId" },
                values: new object[] { 1, new Guid("786f0006-1b4a-4e57-b8a7-88d715a4d429"), 1, true, 1 });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "BarCode", "CustomerId", "IsAvailable", "TicketId" },
                values: new object[] { 2, new Guid("2328084a-cfbd-434a-9a64-475b175cdaba"), 1, true, 8 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BandGenres",
                keyColumns: new[] { "BandId", "GenreId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "BandGenres",
                keyColumns: new[] { "BandId", "GenreId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "BandGenres",
                keyColumns: new[] { "BandId", "GenreId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "BandGenres",
                keyColumns: new[] { "BandId", "GenreId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "BandGenres",
                keyColumns: new[] { "BandId", "GenreId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "BandGenres",
                keyColumns: new[] { "BandId", "GenreId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "BandGenres",
                keyColumns: new[] { "BandId", "GenreId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "BandGenres",
                keyColumns: new[] { "BandId", "GenreId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "BandGenres",
                keyColumns: new[] { "BandId", "GenreId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "PartnerFestivals",
                keyColumns: new[] { "PartnerId", "FestivalId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Performances",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Performances",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Performances",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Performances",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bands",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Partners",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Festivals",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
