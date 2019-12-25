using SF.Domain.Entities.Base;

namespace SF.Domain.Entities
{
    public class AdminEntity : BaseEntity
    {
        public string Login { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
