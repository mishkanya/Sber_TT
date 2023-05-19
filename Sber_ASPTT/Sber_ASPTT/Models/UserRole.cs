using System.ComponentModel.DataAnnotations;

namespace Sber_ASPTT.Models
{
    public class UserRole
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
