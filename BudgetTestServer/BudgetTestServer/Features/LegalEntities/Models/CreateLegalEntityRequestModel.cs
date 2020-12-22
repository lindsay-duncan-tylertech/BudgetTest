using System.ComponentModel.DataAnnotations;

namespace BudgetTestServer.Features.LegalEntities.Models
{
    public class CreateLegalEntityRequestModel
    {
        [Required]
        public string Description { get; set; }

        [Required]
        [Range(100000,999999)]
        public int RegulatoryId { get; set; }
    }
}
