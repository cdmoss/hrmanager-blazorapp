using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRManager.Common.Dtos;

namespace HRManager.Blazor.Services
{
    public class RegistrationService
    {
        public string Step { get; set; }
        public TestRegisterDto Dto { get; set; }
        public event Action OnChange;
        public async Task Set(TestRegisterDto dto)
        {
            Dto = dto;
            OnChange?.Invoke();
        }

        public async Task SetIfNull(TestRegisterDto dto)
        {
            if (Dto == null)
                Dto = dto;
        }
    }
}
