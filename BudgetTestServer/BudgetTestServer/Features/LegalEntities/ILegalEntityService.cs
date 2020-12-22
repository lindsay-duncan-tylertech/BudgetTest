using BudgetTestServer.Features.LegalEntities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetTestServer.Features.LegalEntities
{
    public interface ILegalEntityService
    {
        Task<int> Create(CreateLegalEntityRequestModel model);
        Task<LegalEntityServiceModel> Get(int id);
        Task<IEnumerable<LegalEntityServiceModel>> GetAll();
        Task<bool> Update(int id, UpdateLegalEntityRequestModel model);
        Task<bool> Delete(int id);
    }
}
