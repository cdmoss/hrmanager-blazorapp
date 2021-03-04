using HRManager.Blazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManager.Blazor.Pages.Account.Registration
{
    public class GreetingBase : ComponentBase
    {
        [Inject]
        public IDbSeeder _seeder { get; set; }
        [Inject]
        public IWebHostEnvironment _env { get; set; }

        protected string seedResult = "";
        protected bool isDev = false;

        protected override void OnInitialized()
        {
            isDev = _env.IsDevelopment();
        }

        protected async Task Seed()
        {
            seedResult = await _seeder.Seed();
        }
    }
}
