using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

public class ApiService
{
    private readonly HttpClient _http;
    private readonly string _apiBase;
    private string? _token;

    public ApiService(HttpClient http, string apiBase)
    {
        _http = http;
        _apiBase = apiBase.TrimEnd('/');
    }

    public async Task<bool> LoginAsync(string username, string password)
    {
        var res = await _http.PostAsJsonAsync($"{_apiBase}/auth/login", new { username, password });
        if (!res.IsSuccessStatusCode) return false;
        var json = await res.Content.ReadFromJsonAsync<JsonElement?>();
        _token = json?.GetProperty("token").GetString();
        if (!string.IsNullOrEmpty(_token))
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
        return true;
    }
    public async Task<List<Recipe>> GetRecipesAsync()
    {
        return await _http.GetFromJsonAsync<List<Recipe>>($"{_apiBase}/recipes") ?? new List<Recipe>();
    }
}

public record Recipe(int Id, string Name, string? Description, DateTime CreatedAt);