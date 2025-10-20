using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        [RegularExpression(@".+@.+\.com", ErrorMessage = "Email must contain '@' and '.com'")]
        public required string Email { get; set; }
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Invalid phone number.")]
        public required string Phone { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}
