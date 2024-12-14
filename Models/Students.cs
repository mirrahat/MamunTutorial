using System.ComponentModel.DataAnnotations;

namespace MamunTutorial.Models
{
    public class Students
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string RollNumber { get; set; }

        [Required]
        public string ClassName { get; set; }
    }
}
