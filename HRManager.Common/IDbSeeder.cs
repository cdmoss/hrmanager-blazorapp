using System;
using System.Collections.Generic;
using System.Text;

namespace HRManager.Common
{
    public interface IDbSeeder
    {
        bool Seed(bool isDev);
    }
}
