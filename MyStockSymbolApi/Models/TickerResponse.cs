using System.Collections.Generic;
using System.Text.Json.Serialization;
 
namespace MyStockSymbolApi.Models
{
    public class TickerResponse
    {
        [JsonPropertyName("quotes")]
        public List<Ticker> Quotes { get; set; }
    }
 
    public class Ticker
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
    }
}