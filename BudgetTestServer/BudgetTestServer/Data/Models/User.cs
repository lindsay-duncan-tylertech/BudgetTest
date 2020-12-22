using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BudgetTestServer.Data.Models
{
    public class User : IdentityUser<int>
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
    }
}
