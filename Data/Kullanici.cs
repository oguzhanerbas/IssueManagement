using Microsoft.AspNetCore.Identity;

namespace Identity.Data
{
    public class Kullanici : IdentityUser
    {
        public string AdiSoyadi { get; set; }
    }
}
