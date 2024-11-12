using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class JacketOwner
    {
        [Key]
        public int JacketOwner_Id { get; set; }  // Ensure this property exists and is populated
        public string? JacketOwner_Name { get; set; }  // Ensure this property exists and is populated
        public string? email { get; set; }
        public string? password { get; set; }
    }
}

