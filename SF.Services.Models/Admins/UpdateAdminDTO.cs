
namespace SF.Services.Models.Admins
{
    public class UpdateAdminDTO
    {
        public int Id { get; set; }
        public string NewLogin { get; set; }
        public string NewPassword { get; set; }
    }
}
