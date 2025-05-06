using System.Text;
using AiPlayground.Core.Contracts.Services;
using Newtonsoft.Json;
using OllamaSharp;

namespace AiPlayground.Core.Services;

public class AiMessageService : IAiMessageService
{
    private const string ollamaBaseUrl = "http://localhost:30347";
    private readonly string ollamaEndpoint = ollamaBaseUrl + "/api/generate";
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly OllamaApiClient _ollamaClient;

    public AiMessageService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        _ollamaClient = new OllamaApiClient(new Uri(ollamaBaseUrl));
    }

    public async Task<string> SendPromptViaHttpAsync(string model, string prompt)
    {
        var httpClient = _httpClientFactory.CreateClient();
        try
        {
            var requestBody = new
            {
                model,
                prompt
            };

            var jsonContent = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

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

    public async Task<string> SendPromptViaLibraryAsync(string model, string prompt)
    {
        _ollamaClient.SelectedModel = model;
        var result = "";
        await foreach (var response in _ollamaClient.GenerateAsync(prompt).ConfigureAwait(false))
        {
            result += response.Response;
        }
        return result;
    }
}