using System.Net.Http;
using System.Text.Json;
using MyStockSymbolApi.Models;
 
namespace MyStockSymbolApi.Services
{
   public class TickerService : ITickerService
{
    private readonly HttpClient _httpClient;
 
    public TickerService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }
 
    public async Task<List<StockSymbol>> GetTrendingTickersAsync()
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://yahoo-finance-real-time1.p.rapidapi.com/market/get-trending-tickers?region=US"),
        };
 
        request.Headers.Add("x-rapidapi-key", "71565f1853msh481422c223f54bfp12403cjsna2e91019fa3b");
        request.Headers.Add("x-rapidapi-host", "yahoo-finance-real-time1.p.rapidapi.com");
 
        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
 
        var json = await response.Content.ReadAsStringAsync();
        Console.WriteLine("RAW JSON:\n" + json);
 
        var result = JsonSerializer.Deserialize<TrendingTickersResponse>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
 
        // Extract the required fields
        return result?.Finance?.Result?.FirstOrDefault()?.Quotes?.Select(q => new StockSymbol
        {
            Symbol = q.Symbol,
            RegularMarketPrice = q.RegularMarketPrice,
            RegularMarketChangePercent = q.RegularMarketChangePercent,
            TrendingScore = q.TrendingScore,
            QuoteType = q.QuoteType
        }).ToList() ?? new List<StockSymbol>();
    }
}
}