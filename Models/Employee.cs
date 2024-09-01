using System.ComponentModel.DataAnnotations;

namespace LearnMVC.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [DataType("varchar")]
        [MaxLength(50)]
        [Required]
        public string Name { get; set;} = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [MaxLength(50)]
        [Required]
        public string Password { get; set; } = null!;
    }
}
