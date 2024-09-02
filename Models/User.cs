using System.ComponentModel.DataAnnotations;

namespace LearnMVC.Models
{
    public class User
    {
        //Globally unique ID
        // we need to use [Key] to knowing it's an Primary Key
        [Key]
        public Guid UserId { get; set; }
        public string? UserName { get; set; }

        [DataType(DataType.Password)]
        [MaxLength(50)]
        [Required]
        public string? Password { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
