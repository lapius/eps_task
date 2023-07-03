using EPS_task.Shared.Entities;
using System.Net.Http.Json;

namespace EPS_task.Client.Services.DiscountCodeService
{
    public class DiscountCodeService : IDiscountCodeService
    {
        private readonly HttpClient _http;

        public DiscountCodeService(HttpClient http)
        {
            _http = http;
        }

        public List<DiscountCode> DiscountCodes { get; set; } = new List<DiscountCode>();

        public async Task<string> CreateDiscountCode(GenerateCodeRequest codeRequest)
        {
            return await SetDiscountCodes(await _http.PostAsJsonAsync("api/discountcode", codeRequest));
        }

        private static async Task<string> SetDiscountCodes(HttpResponseMessage result)
        {
            return result.IsSuccessStatusCode ? "Success" : await result.Content.ReadAsStringAsync();
        }

        public async Task GetDiscountCodes()
        {
            var result = await _http.GetFromJsonAsync<List<DiscountCode>>("api/discountcode");
            if (result != null)
                DiscountCodes = result;
        }

        public async Task<string> UpdateDiscountCode(string discountCode)
        {
            return await SetDiscountCodes(await _http.PutAsync($"api/discountcode/{discountCode}", null));
        }

    }
}
