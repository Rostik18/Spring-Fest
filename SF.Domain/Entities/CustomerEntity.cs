using SF.Domain.Entities.Base;

namespace SF.Domain.Entities
{
    public class CustomerEntity : BaseEntity
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
