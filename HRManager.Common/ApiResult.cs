using System;
using System.Collections.Generic;
using System.Text;

namespace HRManager.Common
{
    public class ApiResult<TData>
    {
        public TData Data { get; set; }
        public bool Successful { get; set; }
        public string Error { get; set; }
    }
}
