using Microsoft.AspNetCore.Identity;
using System;

namespace HRManager.Idp.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public int MemberId { get; set; }
    }
}