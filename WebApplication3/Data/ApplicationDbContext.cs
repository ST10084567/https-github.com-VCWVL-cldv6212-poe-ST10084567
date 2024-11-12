using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<FileModel> FileModels { get; set; }
        public DbSet<Jacket> Jackets { get; set; }
        public DbSet<JacketOwner> JacketOwners { get; set; }
        public DbSet<Sighting> Sightings { get; set; }
        public DbSet<WebApplication3.Models.Jacket> Jacket { get; set; } = default!;
    }

    public class FileModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public long FileSize { get; set; }
    }

    public class Jacket
    {
        public int JacketId { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Material { get; set; }
        public JacketOwner JacketOwner { get; set; } // Foreign key relationship
    }

    public class JacketOwner
    {
        public int JacketOwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }
        public ICollection<Jacket> Jackets { get; set; } // One-to-many relationship
    }

    public class Sighting
    {
        public int SightingId { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public Jacket Jacket { get; set; } // Foreign key relationship
    }
}

