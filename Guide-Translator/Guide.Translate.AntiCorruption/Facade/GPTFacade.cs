using Guide.Translate.AntiCorruption.DTO;
using Guide.Translate.AntiCorruption.DTOs;
using Guide.Translate.AntiCorruption.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Guide.Translate.AntiCorruption.Facade
{
    public class GPTFacade : IGPTFacade
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public GPTFacade(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<ChatGPTOutputDTO> Translate(ChatGPTinputDTO translateModel)
        {
            var token = _configuration.GetSection("ChatGptKey");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);

            var requestBody = JsonConvert.SerializeObject(translateModel);

            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/completions", content);

            return await response.Content.ReadFromJsonAsync<ChatGPTOutputDTO>();

        }


    }
}
