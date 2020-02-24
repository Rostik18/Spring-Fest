
namespace SF.Services
{
    public static class Constants
    {
        public static class Email
        {
            public static readonly string sendgridApiKeyName = "SENDGRID_API_KEY";

            public static readonly string senderEmail = "rostik1804@gmail.com";

            public static readonly string tickert = "<p>Шановний(а) {0}, ось ваш квиток!</p><p>Тримайте код в таємниці.</p><p>До зустрічі на фестивалі!</p>" +//0
                "<div style=\"width: 100%;display: flex;justify-content: center;color: #fff;font-family: 'Barlow Condensed', sans-serif;\">" +
                "<div style=\"width: 612px;height: 198px;background-repeat:" +
                " no-repeat;background-size: cover;background-position: center; background-image: " +
                "url('https://www.zelao.ru/files/cache/900x600_adaptiveResize_august_2018_3645644665464465645465.jpg');\">" +
                "<div style=\"display: flex;flex-direction: row;width: 611px;height: 198px;\">" +
                "<div style=\"width: 510px !important;height: 198px;border-right: 2px dashed #fafaface;display: flex;flex-direction: row;\">" +
                "<div style=\"width: 50%;\"></div>" +
                "<div style=\"font-weight: 400;font-size: 21px;margin: 0;text-transform: uppercase;\">" +
                "<h1 style = \"font-weight: 600;font-size: 47px;margin: 0 25px 0 0; white-space: pre;\">Music Festival</h1>" +
                "<div style = \"text-align: end; margin-right: 25px;\"><p style=\"margin: 0;\">Lalala Fest</p><br><p style = \"margin: 0;\" >Тип: {1}</p>" +//1
                "<p style = \"margin: 0;\" >Час: {2}</p><p style = \"margin: 0;\" >Тривалість: {3}</p><p style = \"margin: 0;\" >Ціна: {4}</p></div></div></div>" +//2...
                "<div style=\"width: 101px;height: 198px;position: relative;\"><p style = \"transform: rotate(-90deg); " +
                "margin: 0;white-space: pre;position: absolute;bottom: 25%;right: 0;left: 0;font-weight: 500;font-size: 13px;\" >" +//5
                "{5}</p></div></div></div></div>";
        }
    }
}
