using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Idp.Entities
{
    public interface IConcurrencyAware
    {
        public string ConcurrencyStamp { get; set; }
    }
}
