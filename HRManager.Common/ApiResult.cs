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

        public TData Validate(List<string> errors)
        {
            if (!string.IsNullOrEmpty(Error))
            {
                errors.Add(Error);
            }

            return Data;
        }
    }
}
