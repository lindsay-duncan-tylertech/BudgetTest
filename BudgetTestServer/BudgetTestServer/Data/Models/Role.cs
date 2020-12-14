using Microsoft.AspNetCore.Identity;

namespace BudgetTestServer.Data.Models
{
    public class Role : IdentityRole<int>
    {
        public Role() { }

        public Role(string name)
        {
            Name = name;
        }
    }
}
