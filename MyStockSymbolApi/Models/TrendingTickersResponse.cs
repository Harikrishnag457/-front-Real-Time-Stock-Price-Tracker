public class TrendingTickersResponse
{
    public Finance Finance { get; set; }
}

public class Finance
{
    public List<Result> Result { get; set; }
}

public class Result
{
    public List<StockSymbol> Quotes { get; set; }
}

public class StockSymbol
{
    public string Symbol { get; set; }
    public decimal RegularMarketPrice { get; set; }
    public decimal RegularMarketChangePercent { get; set; }
    public decimal TrendingScore { get; set; }
    public string QuoteType { get; set; }
}