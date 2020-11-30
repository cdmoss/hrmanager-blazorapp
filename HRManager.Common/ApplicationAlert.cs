using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Common
{
    [Serializable]
    public class ApplicationAlert : Alert
    {
        public ApplicationAlert()
        {
            AlertType = "application";
        }

        protected override string GetDescription()
        {
            return $"Recieved a new application from {Member.FirstName} {Member.LastName}";
        }
    }
}
