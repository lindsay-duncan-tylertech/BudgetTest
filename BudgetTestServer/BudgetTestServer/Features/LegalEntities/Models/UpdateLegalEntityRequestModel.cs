using System.ComponentModel.DataAnnotations;

namespace BudgetTestServer.Features.LegalEntities.Models
{
    public class UpdateLegalEntityRequestModel
    {
        public string Description { get; set; }

        [Range(100000, 999999)]
        public int RegulatoryId { get; set; }
    }
}
