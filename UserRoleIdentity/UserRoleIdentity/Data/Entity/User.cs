using Microsoft.AspNetCore.Identity;

namespace UserRoleIdentity.Data.Entity
{
    public class User:IdentityUser<int>
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
