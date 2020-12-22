using BudgetTestServer.Data;
using BudgetTestServer.Data.Models;
using BudgetTestServer.Features.LegalEntities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetTestServer.Features.LegalEntities
{
    public class LegalEntityService : ILegalEntityService
    {
        private readonly ApplicationDbContext data;

        public LegalEntityService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public async Task<int> Create(CreateLegalEntityRequestModel model)
        {
            var legalEntity = new LegalEntity
            {
                Description = model.Description,
                RegulatoryId = model.RegulatoryId
            };

            this.data.Add(legalEntity);

            await this.data.SaveChangesAsync();

            return legalEntity.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var legalEntity = await this.GetLegalEntityById(id);

            if (legalEntity == null)
            {
                return false;
            }

            this.data.LegalEntity.Remove(legalEntity);

            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<LegalEntityServiceModel>> GetAll()
        {
            return await this.data.LegalEntity
                .Select(e => new LegalEntityServiceModel
                {
                    Id = e.Id,
                    Description = e.Description,
                    RegulatoryId = e.RegulatoryId
                })
                .ToListAsync();
        }

        public async Task<LegalEntityServiceModel> Get(int id)
        {
            return await this.data.LegalEntity
                .Where(e => e.Id == id)
                .Select(e => new LegalEntityServiceModel
                {
                    Id = e.Id,
                    Description = e.Description,
                    RegulatoryId = e.RegulatoryId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> Update(int id, UpdateLegalEntityRequestModel model)
        {
            var legalEntity = await this.GetLegalEntityById(id);

            if (legalEntity == null)
            {
                return false;
            }

            if (!string.IsNullOrWhiteSpace(model.Description) && legalEntity.Description != model.Description)
            {
                legalEntity.Description = model.Description;
            }

            if (legalEntity.RegulatoryId != model.RegulatoryId)
            {
                legalEntity.RegulatoryId = model.RegulatoryId;
            }

            await this.data.SaveChangesAsync();

            return true;
        }

        private async Task<LegalEntity> GetLegalEntityById(int id)
        {
            return await this.data.LegalEntity
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
