using Microsoft.EntityFrameworkCore;
using SF.Domain.Entities;
using SF.Domain.Enumerations;
using System;

namespace SF.Infrastructure
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminEntity>().HasData(
                new AdminEntity
                {
                    Id = 1,
                    Login = "MasterOfPuppets",
                    PasswordHash = new byte[] { 245, 118, 89, 111, 219, 76, 234, 229, 151, 177, 131, 188, 169, 101, 58, 158, 8, 4, 215, 11, 224, 167, 3, 2, 160, 202, 135, 125, 37, 212, 140, 41, 236, 32, 34, 68, 1, 51, 55, 243, 27, 100, 146, 224, 151, 67, 32, 110, 151, 97, 84, 18, 80, 9, 55, 250, 17, 45, 100, 134, 198, 0, 229, 55 },
                    PasswordSalt = new byte[] { 252, 227, 231, 127, 101, 15, 116, 42, 144, 252, 178, 132, 222, 159, 237, 250, 155, 137, 42, 17, 248, 104, 214, 124, 58, 10, 29, 191, 147, 128, 162, 131, 27, 130, 67, 61, 68, 244, 14, 186, 66, 207, 64, 120, 247, 79, 246, 117, 140, 71, 190, 200, 32, 129, 225, 158, 86, 55, 103, 81, 45, 153, 248, 52, 197, 59, 87, 148, 44, 157, 190, 25, 217, 119, 84, 123, 22, 17, 109, 227, 174, 237, 245, 200, 98, 225, 196, 89, 105, 201, 137, 228, 112, 170, 107, 120, 234, 29, 206, 83, 124, 109, 220, 159, 99, 167, 14, 87, 81, 114, 70, 133, 254, 41, 166, 138, 181, 91, 154, 122, 248, 222, 164, 36, 128, 133, 32, 10 }
                });

            modelBuilder.Entity<GenreEntity>().HasData(
                new GenreEntity
                {
                    Id = 1,
                    Name = "Rock"
                },
                new GenreEntity
                {
                    Id = 2,
                    Name = "Hard Rock"
                },
                new GenreEntity
                {
                    Id = 3,
                    Name = "Pop Rock"
                },
                new GenreEntity
                {
                    Id = 4,
                    Name = "Folk Rock"
                },
                new GenreEntity
                {
                    Id = 5,
                    Name = "Punk Rock"
                },
                new GenreEntity
                {
                    Id = 6,
                    Name = "Psychedelic Rock"
                },
                new GenreEntity
                {
                    Id = 7,
                    Name = "Heavy Metal"
                },
                new GenreEntity
                {
                    Id = 8,
                    Name = "Thrash"
                },
                new GenreEntity
                {
                    Id = 9,
                    Name = "Pop"
                },
                new GenreEntity
                {
                    Id = 10,
                    Name = "Hip Hop"
                },
                new GenreEntity
                {
                    Id = 11,
                    Name = "Rep"
                },
                new GenreEntity
                {
                    Id = 12,
                    Name = "R & В"
                },
                new GenreEntity
                {
                    Id = 13,
                    Name = "Jazz"
                });

            modelBuilder.Entity<BandEntity>().HasData(
                new BandEntity
                {
                    Id = 1,
                    Name = "Metallica",
                    Description = "Metallica — американський метал-гурт з Лос-Анджелеса, Каліфорнія, яка грає в жанрі треш-метал та хеві-метал. Разом з Slayer, Megadeth та Anthrax входять до «великої четвірки треш-металу». Заснований в 1981 році, коли Джеймс Гетфілд відгукнувся на оголошення барабанщика Ларса Ульріха, розміщене у місцевій газеті.",
                    PhotoURL = "https://pimg.mycdn.me/getImage?disableStub=true&type=VIDEO_S_720&skipBlack=true&url=http%3A%2F%2Fi.mycdn.me%2Fimage%3Fid%3D880168864240%26t%3D50%26plc%3DWEB%26tkn%3D*YEVP-NmKvHWbv6RBRnyQxd8Vizs&signatureToken=hb9KMZKxbZF4GYN-Vq8Tuw"
                },
                new BandEntity
                {
                    Id = 2,
                    Name = "Bring Me the Horizon",
                    Description = "Bring Me The Horizon — англійський металкор гурт з міста Шеффілда, заснований в 2004 році. В цей час група складається з вокаліста Олівера Сайкса, гітариста Лі Малії, басиста Метта Кіна, барабанщика Метта Ніколлса і клавішника Джордана Фіша. На сьогодні гурт співпрацює з лейблами RCA Records та Epitaph Records.",
                    PhotoURL = "https://i2.wp.com/sova.ponominalu.ru/wp-content/uploads/2019/10/Bring-Me-The-Horizon.jpg?fit=1548%2C1024&ssl=1"
                },
                new BandEntity
                {
                    Id = 3,
                    Name = "Lord of the Lost",
                    Description = "Lord of the Lost - німецький готичний металевий гурт з Гамбурга. Гурт створив співак і фронтмен Кріс Хармс.",
                    PhotoURL = "https://fainemisto.com.ua/wp-content/uploads/2019/07/1530649229.jpg"
                },
                new BandEntity
                {
                    Id = 4,
                    Name = "Led Zeppelin",
                    Description = "Led Zeppelin - британський рок-гурт, що вважається одним із засновників хард-року та хеві-металу. Led Zeppelin досі високо шанується за музичні досягнення, нестандартність, комерційний успіх і широкий вплив.",
                    PhotoURL = "https://kanal5.com.mk/uploads/10-5526-.jpg"
                });

            modelBuilder.Entity<BandGenreEntity>().HasData(
                //Metallica
                new BandGenreEntity
                {
                    BandId = 1,
                    GenreId = 7
                },
                new BandGenreEntity
                {
                    BandId = 1,
                    GenreId = 8
                },

                //Bring Me the Horizon
                new BandGenreEntity
                {
                    BandId = 2,
                    GenreId = 2
                },
                new BandGenreEntity
                {
                    BandId = 2,
                    GenreId = 3
                },
                new BandGenreEntity
                {
                    BandId = 2,
                    GenreId = 9
                },

                //Lord of the Lost
                new BandGenreEntity
                {
                    BandId = 3,
                    GenreId = 1
                },
                new BandGenreEntity
                {
                    BandId = 3,
                    GenreId = 7
                },

                //Led Zeppelin
                new BandGenreEntity
                {
                    BandId = 4,
                    GenreId = 1
                },
                new BandGenreEntity
                {
                    BandId = 4,
                    GenreId = 7
                });

            modelBuilder.Entity<StageEntity>().HasData(
                new StageEntity
                {
                    Id = 1,
                    Name = "Main Stage"
                },
                new StageEntity
                {
                    Id = 2,
                    Name = "White Stage"
                },
                new StageEntity
                {
                    Id = 3,
                    Name = "Black Stage"
                });

            modelBuilder.Entity<PartnerEntity>().HasData(
                new PartnerEntity
                {
                    Id = 1,
                    Name = "Samsung",
                    Description = "Samsung — південнокорейська транснаціональна компанія-конгломерат, головний офіс якої розташований у Сеулі, Південна Корея. Компанія є найбільшим південнокорейським чеболем."
                });

            modelBuilder.Entity<FestivalEntity>().HasData(
                new FestivalEntity
                {
                    Id = 1,
                    Location = "https://www.google.com.ua/maps/place/%D0%90%D0%B5%D1%80%D0%BE%D0%B4%D1%80%D0%BE%D0%BC+%C2%AB%D0%A6%D1%83%D0%BD%D1%96%D0%B2%C2%BB+-+%D1%81%D1%82%D1%80%D0%B8%D0%B1%D0%BA%D0%B8+%D0%B7+%D0%BF%D0%B0%D1%80%D0%B0%D1%88%D1%83%D1%82%D0%BE%D0%BC/@49.8211939,23.6848984,16.48z/data=!4m5!3m4!1s0x473b1e99ccdc9dd9:0xb5a7d47bdfe021fc!8m2!3d49.8215501!4d23.6873576?hl=uk",
                    Year = "2020"
                });

            modelBuilder.Entity<PartnerFestivalEntity>().HasData(
                new PartnerFestivalEntity
                {
                    FestivalId = 1,
                    PartnerId = 1
                });

            modelBuilder.Entity<PerformanceEntity>().HasData(
                 //Metallica
                 new PerformanceEntity
                 {
                     Id = 1,
                     BandId = 1,
                     StageId = 1,
                     FestivalId = 1,
                     BeginingTime = new DateTimeOffset(new DateTime(2020, 8, 30, 22, 0, 0)),
                     Duration = new TimeSpan(1, 20, 0)
                 },
                 //BMTH
                 new PerformanceEntity
                 {
                     Id = 2,
                     BandId = 2,
                     StageId = 1,
                     FestivalId = 1,
                     BeginingTime = new DateTimeOffset(new DateTime(2020, 8, 29, 22, 0, 0)),
                     Duration = new TimeSpan(1, 10, 0)
                 },
                 //LOTR
                 new PerformanceEntity
                 {
                     Id = 3,
                     BandId = 3,
                     StageId = 3,
                     FestivalId = 1,
                     BeginingTime = new DateTimeOffset(new DateTime(2020, 8, 30, 22, 0, 0)),
                     Duration = new TimeSpan(1, 20, 0)
                 },
                 //Led Zeppelin
                 new PerformanceEntity
                 {
                     Id = 4,
                     BandId = 4,
                     StageId = 2,
                     FestivalId = 1,
                     BeginingTime = new DateTimeOffset(new DateTime(2020, 8, 30, 20, 0, 0)),
                     Duration = new TimeSpan(1, 10, 0)
                 });

            modelBuilder.Entity<TicketEntity>().HasData(
                new TicketEntity
                {
                    Id = 1,
                    FestivalId = 1,
                    Price = 1000,
                    BeginingTime = new DateTimeOffset(new DateTime(2020, 8, 28, 12, 0, 0)),
                    Duration = 3,
                    Type = TicketType.Festival
                },
                new TicketEntity
                {
                    Id = 2,
                    FestivalId = 1,
                    Price = 700,
                    BeginingTime = new DateTimeOffset(new DateTime(2020, 8, 28, 12, 0, 0)),
                    Duration = 2,
                    Type = TicketType.Festival
                },
                new TicketEntity
                {
                    Id = 3,
                    FestivalId = 1,
                    Price = 700,
                    BeginingTime = new DateTimeOffset(new DateTime(2020, 8, 29, 12, 0, 0)),
                    Duration = 2,
                    Type = TicketType.Festival
                },
                new TicketEntity
                {
                    Id = 4,
                    FestivalId = 1,
                    Price = 500,
                    BeginingTime = new DateTimeOffset(new DateTime(2020, 8, 28, 12, 0, 0)),
                    Duration = 1,
                    Type = TicketType.Festival
                },
                new TicketEntity
                {
                    Id = 5,
                    FestivalId = 1,
                    Price = 500,
                    BeginingTime = new DateTimeOffset(new DateTime(2020, 8, 29, 12, 0, 0)),
                    Duration = 1,
                    Type = TicketType.Festival
                },
                new TicketEntity
                {
                    Id = 6,
                    FestivalId = 1,
                    Price = 500,
                    BeginingTime = new DateTimeOffset(new DateTime(2020, 8, 30, 12, 0, 0)),
                    Duration = 1,
                    Type = TicketType.Festival
                },
                new TicketEntity
                {
                    Id = 7,
                    FestivalId = 1,
                    Price = 200,
                    BeginingTime = new DateTimeOffset(new DateTime(2020, 8, 28, 12, 0, 0)),
                    Duration = 3,
                    Type = TicketType.Parking
                },
                new TicketEntity
                {
                    Id = 8,
                    FestivalId = 1,
                    Price = 300,
                    BeginingTime = new DateTimeOffset(new DateTime(2020, 8, 28, 12, 0, 0)),
                    Duration = 3,
                    Type = TicketType.Tent
                });

            modelBuilder.Entity<CustomerEntity>().HasData(
                new CustomerEntity
                {
                    Id = 1,
                    Email = "rostik1804@gmail.com",
                    FirstName = "Ростислав",
                    LastName = "Байцар"
                });

            modelBuilder.Entity<PurchaseEntity>().HasData(
                new PurchaseEntity
                {
                    Id = 1,
                    IsAvailable = true,
                    BarCode = Guid.NewGuid(),
                    CustomerId = 1,
                    TicketId = 1
                },
                new PurchaseEntity
                {
                    Id = 2,
                    IsAvailable = true,
                    BarCode = Guid.NewGuid(),
                    CustomerId = 1,
                    TicketId = 8
                });
        }
    }
}
