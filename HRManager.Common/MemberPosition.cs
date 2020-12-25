using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Common
{
    public enum AssociationType
    {
        Preferred,
        Assigned,
        PreferredAndAssigned
    }

    [Serializable]
    public class MemberPosition
    {

        public int Id { get; set; }
        public MemberProfile Member { get; set; }
        public Position Position { get; set; }
        public AssociationType Association { get; set; }
    }
}
