using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MyStockSymbolApi.Models;

namespace MyStockSymbolApi.Data
{
    public class StockSymbolRepository : IStockSymbolRepository
    {
        private readonly string _jsonFilePath;

        public StockSymbolRepository(IConfiguration configuration)
        {
            // JSON file path defined in appsettings.json
            _jsonFilePath = configuration["StockSymbolsJsonFilePath"];
        }

        public async Task<List<StockSymbol>> GetSymbolsAsync()
        {
            if (!File.Exists(_jsonFilePath))
                throw new FileNotFoundException("Stock symbols JSON file not found.", _jsonFilePath);

            using var stream = new FileStream(_jsonFilePath, FileMode.Open, FileAccess.Read);
            return await JsonSerializer.DeserializeAsync<List<StockSymbol>>(stream);
        }
    }
}
