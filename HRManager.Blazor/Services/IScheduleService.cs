//using HRManager.Common.Dtos;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Net.Http.Json;
//using System.Threading.Tasks;

//namespace HRManager.Blazor.Services
//{
//    public interface IScheduleService
//    {
//        Task<ScheduleDto> GetScheduleData();
//    }

//    public class HttpScheduleService : IScheduleService
//    {
//        private readonly HttpClient _http;

//        public HttpScheduleService(HttpClient http)
//        {
//            _http = http;
//        }

//        public async Task<ScheduleDto> GetScheduleData()
//        {
//            return await _http.GetFromJsonAsync<ScheduleDto>("schedule/data");
//        }
//    }
//}
