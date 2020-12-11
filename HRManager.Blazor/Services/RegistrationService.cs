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
        public MemberRegisterDto Dto { get; set; }
        public event Action OnChange;
        public async Task Set(MemberRegisterDto dto)
        {
            Dto = dto;
            OnChange?.Invoke();
        }

        public async Task SetIfNull(MemberRegisterDto dto)
        {
            if (Dto == null)
                Dto = dto;
        }
    }
}
