using AutoMapper;
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
        private readonly IMapper mapper;

        public LegalEntityService(ApplicationDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public async Task<int> Create(CreateLegalEntityRequestModel model)
        {
            var legalEntity = mapper.Map<LegalEntity>(model);

            this.data.Add(legalEntity);

            await this.data.SaveChangesAsync();

            return legalEntity.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var legalEntity = await this.data.LegalEntity.FindAsync(id);

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
                .Select(e => mapper.Map<LegalEntityServiceModel>(e))
                .ToListAsync();
        }

        public async Task<LegalEntityServiceModel> Get(int id)
        {
            return await this.data.LegalEntity
                .Where(e => e.Id == id)
                .Select(e => mapper.Map<LegalEntityServiceModel>(e))
                .FirstOrDefaultAsync();
        }

        public async Task<bool> Update(int id, UpdateLegalEntityRequestModel model)
        {
            var legalEntity = await this.data.LegalEntity.FindAsync(id);

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

    }
}
