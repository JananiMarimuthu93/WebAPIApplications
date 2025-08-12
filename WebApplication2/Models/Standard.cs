using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Standard
    {
        public int StandardId { get; set; }
        public string StandardName { get; set; }
        public string Description { get; set; }
        public List<Student>? Students { get; set; }
    }
}