using System;
using System.Collections.Generic;
using System.Text;

namespace HRManager.Api.Services
{
    public interface IDbSeeder
    {
        bool Seed(bool isDev);
    }
}
