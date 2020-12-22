using System.ComponentModel.DataAnnotations;

namespace BudgetTestServer.Data.Models
{
    public class LegalEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Description { get; set; }

        [Required]
        [Range(100000, 999999)]
        public int RegulatoryId { get; set; }
    }
}
