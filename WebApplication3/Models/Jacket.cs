using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Jacket
    {
        [Key]
        public int Jacket_Id { get; set; }  // Ensure this property exists and is populated
        public string? Jacket_Name { get; set; }  // Ensure this property exists and is populated
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? Location { get; set; }
    }
}

