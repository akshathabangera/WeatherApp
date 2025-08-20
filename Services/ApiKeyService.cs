using Microsoft.Maui.Storage;

public class ApiKeyService
{
    private const string ApiKeyKey = "weather_api_key";

    // Save API Key securely
    public async Task SaveApiKeyAsync(string apiKey)
    {
        await SecureStorage.Default.SetAsync(ApiKeyKey, apiKey);
    }

    // Retrieve API Key
    public async Task<string?> GetApiKeyAsync()
    {
        return await SecureStorage.Default.GetAsync(ApiKeyKey);
    }

    // Remove API Key
    public void RemoveApiKey()
    {
        SecureStorage.Default.Remove(ApiKeyKey);
    }
}