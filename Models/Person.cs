using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Person
    {
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please provide proper age")]
        public int Age { get; set; }
        public float Weight { get; set; }
        public int Height { get; set; }
        [Required]
        public string Sex { get; set; }
    }
}