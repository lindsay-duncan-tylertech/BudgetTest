using BudgetTestServer.Features.LegalEntities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetTestServer.Features.LegalEntities
{
    public class LegalEntityController : ApiController
    {
        private readonly ILegalEntityService legalEntityService;

        public LegalEntityController(ILegalEntityService legalEntityService)
        {
            this.legalEntityService = legalEntityService;
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<LegalEntityServiceModel>> GetAll()
        {
            return await this.legalEntityService.GetAll();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<LegalEntityServiceModel> Get(int id)
        {
            return await this.legalEntityService.Get(id);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(CreateLegalEntityRequestModel model)
        {
            var id = await this.legalEntityService.Create(model);

            return Created(nameof(this.Create), id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update(int id, UpdateLegalEntityRequestModel model)
        {
            var result = await this.legalEntityService.Update(id, model);

            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await this.legalEntityService.Delete(id);

            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
