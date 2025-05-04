using System.Text;
using DeepSeek.WPF.Core.Contracts.Services;
using Newtonsoft.Json;
using OllamaSharp;

namespace DeepSeek.WPF.Core.Services;

public class AiMessageService : IAiMessageService
{
    private readonly string ollamaEndpoint = "http://localhost:51042/api/generate";
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly OllamaApiClient _ollamaClient;

    public AiMessageService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        _ollamaClient = new OllamaApiClient(new Uri("http://localhost:51042"));
        _ollamaClient.SelectedModel = "llama3";// deepseek-r1:1.5b, llama3
    }

    public async Task<string> SendPromptViaHttpAsync(string prompt)
    {
        var httpClient = _httpClientFactory.CreateClient();
        try
        {
            var requestBody = new
            {
                model = "deepseek-r1:1.5b", // deepseek-r1:1.5b, llama3
                prompt
            };

            var jsonContent = JsonConvert.SerializeObject(requestBody);
            StringContent content = new(jsonContent, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(ollamaEndpoint, content);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            else
            {
                return $"Error: {response.StatusCode}";
            }
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }

    public async Task<string> SendPromptViaLibraryAsync(string prompt)
    {
        var result = "";
        await foreach (var response in _ollamaClient.GenerateAsync(prompt))
        {
            result += response.Response;
        }
        return result;
    }
}