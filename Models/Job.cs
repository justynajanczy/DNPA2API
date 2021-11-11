using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Job
    {
        public string JobTitle { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please provide relevant salary")]
        public int Salary { get; set; }
    }
}