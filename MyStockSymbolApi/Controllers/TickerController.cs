using Microsoft.AspNetCore.Mvc;
using MyStockSymbolApi.Services;
 
namespace MyStockSymbolApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TickerController : ControllerBase
    {
        private readonly ITickerService _tickerService;
 
        public TickerController(ITickerService tickerService)
        {
            _tickerService = tickerService;
        }
 
        [HttpGet("trending")]
        public async Task<IActionResult> GetTrendingTickers()
        {
            var tickers = await _tickerService.GetTrendingTickersAsync();

            // Filter the data to include only the required fields
            var filteredTickers = tickers.Select(t => new
            {
                t.Symbol,
                t.RegularMarketPrice,
                t.RegularMarketChangePercent,
                t.TrendingScore,
                t.QuoteType
            });

            return Ok(filteredTickers);
        }
    }
}