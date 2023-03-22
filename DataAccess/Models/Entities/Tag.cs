using System.ComponentModel.DataAnnotations.Schema;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace DataAccess.Models.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    [Table("tags")]
    public class Tag
    {
        public long? Id { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
