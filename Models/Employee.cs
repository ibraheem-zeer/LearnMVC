using System.ComponentModel.DataAnnotations;

namespace LearnMVC.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [DataType("varchar")]
        [MaxLength(50)]
        [Required]
        [Display(Name="Employee Name")]
        public string Name { get; set;} = null!;

        [Required]
        [EmailAddress]
        [Display(Name = "Employee Email")]
        public string Email { get; set; }
         
        [DataType(DataType.Password)]
        [MaxLength(50)]
        [Required]
        [Display(Name = "Employee Password")]
        public string Password { get; set; } = null!;
    }
}
