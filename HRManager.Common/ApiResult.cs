using System;
using System.Collections.Generic;
using System.Text;

namespace HRManager.Common
{
    public class ApiResult<TDto>
    {
        public TDto Dto { get; set; }
        public bool Successful { get; set; }
        public string Error { get; set; }
    }
}
