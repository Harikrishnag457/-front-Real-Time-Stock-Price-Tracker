using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStockSymbolApi.Services;

namespace MyStockSymbolApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockSymbolsController : ControllerBase
    {
        private readonly IStockSymbolService _service;

        public StockSymbolsController(IStockSymbolService service)
        {
            _service = service;
        }

        // GET: api/StockSymbols/suggestions?query=A
        [HttpGet("suggestions")]
        public async Task<IActionResult> GetSuggestions([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
            return BadRequest(new
            {
            title = "The query parameter is required.",
            status = 400
        });
    }

    var suggestions = await _service.GetSuggestionsAsync(query);
    return Ok(suggestions);
}

    }
}
