using Microsoft.AspNetCore.Mvc;

namespace BudgetTestServer.Features
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
    }
}
