using System.Net.Http.Json;

using PaySpace.Calculator.Web.Services.Abstractions;
using PaySpace.Calculator.Web.Services.Models;

namespace PaySpace.Calculator.Web.Services
{
    public class CalculatorHttpService : ICalculatorHttpService
    {
        HttpClient httpClient = new HttpClient();
        public async Task<List<PostalCode>> GetPostalCodesAsync()
        {
            
            var response = await httpClient.GetAsync("api/posta1code");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Cannot fetch postal codes, status code: {response.StatusCode}");
            }

            return await response.Content.ReadFromJsonAsync<List<PostalCode>>() ?? [];
        }

        public async Task<List<CalculatorHistory>> GetHistoryAsync()
        {
            
            var response = await httpClient.GetAsync("https://localhost:7119/api/Calculator/history");
            return await response.Content.ReadFromJsonAsync<List<CalculatorHistory>>() ?? [];
        }

        public async Task<CalculateResult> CalculateTaxAsync(CalculateRequest calculationRequest)
        {
            throw new NotImplementedException();
        }
    }
}