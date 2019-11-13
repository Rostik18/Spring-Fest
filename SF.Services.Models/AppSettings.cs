
namespace SF.Services.Models
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }
        public SwaggerSettings SwaggerSettings { get; set; }
        public JwtSettings JwtSettings { get; set; }
        public Admin Admin { get; set; }
    }


    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Expires { get; set; }
    }

    public class SwaggerSettings
    {
        public SwaggerInfoSettings SwaggerInfoSettings { get; set; }

        public SwaggerApiSchemeSettings SwaggerApiSchemeSettings { get; set; }
    }

    public class SwaggerInfoSettings
    {
        public string Version { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }

    public class SwaggerApiSchemeSettings
    {
        public string In { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class Admin
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
