using ClkTeknoloji.Shared.DTOs;
using ClkTeknoloji.Shared.ResponseModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClkTeknoloji.Shared.Service.DropDowns
{
    public class DropDownService : IDropDownService
    {
        private readonly HttpClient _httpClient;

        public DropDownService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ServiceDto>> GetAllService()
        {
            var response = await _httpClient.GetAsync("api/dropdown/services");

            var resultString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<List<ServiceDto>>>(resultString);

            if (!result.Success)
            {

            }

            return result.Value;
        }
    }
}
