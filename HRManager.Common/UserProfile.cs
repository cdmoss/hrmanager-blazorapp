using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using HRManager.Common;
using Microsoft.AspNetCore.Identity;

namespace HRManager.Common
{
    [Serializable]
    public class UserProfile : IdentityUser<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        public MemberProfile Member { get; set; }
    }
}
