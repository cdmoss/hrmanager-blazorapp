using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Blazor.Services
{
    public class TokenProvider
    {
        public string XsrfToken { get; set; }
        public string AccessToken { get; set; }
    }
    public class InitialApplicationState
    {
        public string XsrfToken { get; set; }
        public string AccessToken { get; set; }
    }
}
