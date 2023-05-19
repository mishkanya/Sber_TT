using System.ComponentModel.DataAnnotations;

namespace Sber_ASPTT.Models
{
    public class Contact
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [RegularExpression(@"([А-ЯЁ][а-яё]+[\-\s]?){3,}", ErrorMessage = "Некорректный адрес")]
        public string Name { get; set; }

        [Required]
        [UIHint("email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [UIHint("Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }
    }
}
