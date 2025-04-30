using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStockSymbolApi.Data;
using MyStockSymbolApi.Models;

namespace MyStockSymbolApi.Services
{
    public class StockSymbolService : IStockSymbolService
    {
        private readonly IStockSymbolRepository _repository;

        public StockSymbolService(IStockSymbolRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<StockSymbol>> GetSuggestionsAsync(string query)
        {
            var symbols = await _repository.GetSymbolsAsync();

            if (string.IsNullOrWhiteSpace(query))
                return symbols;

            // Filter symbols that start with the query (case-insensitive)
            return symbols.Where(s => 
                            s.Symbol.StartsWith(query, StringComparison.OrdinalIgnoreCase))
                          .ToList();
        }
    }
}
