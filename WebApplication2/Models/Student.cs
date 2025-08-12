using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication2.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StandardId { get; set; }
        [ForeignKey("StandardId")]
        //[JsonIgnore]
        public virtual Standard? Standard { get; set; }
    }
}