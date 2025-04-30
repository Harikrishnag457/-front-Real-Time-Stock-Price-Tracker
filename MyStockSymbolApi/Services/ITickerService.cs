using System.Collections.Generic;
using System.Threading.Tasks;
using MyStockSymbolApi.Models;

namespace MyStockSymbolApi.Services
{
    public interface ITickerService
    {
        Task<List<StockSymbol>> GetTrendingTickersAsync();
    }
}